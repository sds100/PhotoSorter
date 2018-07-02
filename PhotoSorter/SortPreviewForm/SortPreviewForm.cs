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
            var nodes = CreateTreeNodeListFromGroups(groupList, rootNode);

            rootNode.Nodes.AddRange(nodes);

            treeView.Nodes.Add(rootNode);
        }

        private TreeNode[] CreateTreeNodeListFromGroups(List<Group> groupList, TreeNode parentNode)
        {
            var treeNodeList = new List<TreeNode>();

            foreach (var group in groupList)
            {
                if (group.HasChildrenGroups)
                {
                    var node = new TreeNode(group.Name);

                    node.Nodes.AddRange(CreateTreeNodeListFromGroups(group.ChildrenGroups, node));

                    treeNodeList.Add(node);
                }
                else
                {
                    //map the file names to a TreeNode list
                    var fileNodes = group.Files.Select(item => new TreeNode(item.FileName));

                    parentNode.Nodes.AddRange(fileNodes.ToArray());
                }
            }

            return treeNodeList.ToArray();
        }
    }
}
