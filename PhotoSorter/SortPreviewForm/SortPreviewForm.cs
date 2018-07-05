using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace PhotoSorter.SortPreviewForm
{
    public partial class SortPreviewForm : Form, IForm
    {
        public const int MOVE = 0;
        public const int COPY = 1;

        private readonly IPresenter Presenter;

        public int MoveOrCopy
        {
            get
            {
                if (radioButtonMove.Checked)
                {
                    return MOVE;
                }
                else if (radioButtonCopy.Checked)
                {
                    return COPY;
                }

                return 2;
            }
        }

        public SortPreviewForm(SortPreviewResult sortPreviewResult)
        {
            InitializeComponent();
            Presenter = new Presenter(this, sortPreviewResult);

            labelOutputDirectory.Text = sortPreviewResult.OutputDirectory;
        }

        public void AddNodesToTree(List<string> unknownFiles, List<Group> groupList)
        {
            //only create an unknown files node if there are unknown files
            if (unknownFiles.Count > 0)
            {
                //Create a node for unknown files.
                var unknownFilesNodes = unknownFiles.Select(filePath => new TreeNode(filePath));
                var unknownFileNode = new TreeNode("Unknown Files", unknownFilesNodes.ToArray());

                treeView.Nodes.Add(unknownFileNode);
            }

            //Create a node for all the files that can be sorted.
            var rootNode = new TreeNode("Files to sort");

            AddChildGroupNodesToNode(groupList, rootNode);

            treeView.Nodes.Add(rootNode);
        }

        private void AddChildGroupNodesToNode(List<Group> groupList, TreeNode parentNode)
        {
            foreach (var group in groupList)
            {
                var node = new TreeNode(group.Name.ToString());

                if (group.HasChildrenGroups)
                {
                    AddChildGroupNodesToNode(group.ChildrenGroups, node);
                }
                else
                {
                    //map the file names to a TreeNode list
                    var fileNodes = group.Files.Select(item => new TreeNode(item.FilePath));

                    node.Nodes.AddRange(fileNodes.ToArray());
                }

                parentNode.Nodes.Add(node);
            }
        }

        private void ButtonConfirm_Click(object sender, System.EventArgs e)
        {
            var progressDialog = new ProgressDialog("Saving sorted files to disk");
            Presenter.Sort(progressDialog);
        }

        public void OnProgressCompleted()
        {
            MessageBox.Show("Your files have been sorted.");
            this.Close();
        }
    }
}
