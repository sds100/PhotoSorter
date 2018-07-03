using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace PhotoSorter.SortPreviewForm
{
    public partial class SortPreviewForm : Form, IForm
    {
        private readonly IPresenter Presenter;

        public SortPreviewForm(SortPreviewResult sortPreviewResult)
        {
            InitializeComponent();
            Presenter = new Presenter(this, sortPreviewResult);
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
                var node = new TreeNode(group.Name);

                if (group.HasChildrenGroups)
                {
                    AddChildGroupNodesToNode(group.ChildrenGroups, node);
                }
                else
                {
                    //map the file names to a TreeNode list
                    var fileNodes = group.Files.Select(item => new TreeNode(item.FileName));

                    node.Nodes.AddRange(fileNodes.ToArray());
                }

                parentNode.Nodes.Add(node);
            }
        }
    }
}
