﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum PageType
{
    Card = 0,
    Monster = 1,
    Category = 2
}

namespace Enciclopedia
{
    internal class TreeNode<Type>
    {
        public Type pageName;
        public PageType pageType = PageType.Category;

        private int _access = 0;

        private TreeNode<Type>? _parent;
        private List<TreeNode<Type>> _children = new List<TreeNode<Type>>();

        public TreeNode<Type>? Parent => _parent;
        public int Access => _access;

        public TreeNode(Type value, TreeNode<Type>? parent = null)
        {
            this.pageName = value;
            _parent = parent;
        }

        public TreeNode<Type> AddChild(Type value)
        {
            TreeNode<Type> newNode = new TreeNode<Type>(value, this);
            _children.Add(newNode);
            return newNode;
        }

        public TreeNode<Type>? RemoveChildByIndex(int index)
        {
            if (index >= 0 && index < _children.Count)
            {
                TreeNode<Type> node = _children[index];
                node._parent = null;
                _children.RemoveAt(index);
                return node;
            }
            return null;
        }

        public TreeNode<Type>? GetChild(int index)
        {
            if (index >= 0 && index < _children.Count)
            {
                return _children[index];
            }
            return null;
        }


        public void ProcessPreOrder(Action<TreeNode<Type>> function)
        {
            function(this);
            foreach (var child in _children)
            {
                child.ProcessPreOrder(function);
            }
        }

        public void ProcessPostOrder(Action<TreeNode<Type>> function)
        {
            foreach (var child in _children)
            {
                child.ProcessPostOrder(function);
            }
            function(this);
        }

        public void ProcessBreadthFirst(Action<TreeNode<Type>> function)
        {
            Queue<TreeNode<Type>> queue = new Queue<TreeNode<Type>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var child in node._children)
                {
                    queue.Enqueue(child);
                }
                function(node);
            }
        }

        public void AddAccess()
        {
            _access++;
        }
    }
}
