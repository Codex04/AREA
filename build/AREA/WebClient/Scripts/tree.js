﻿//TREE STRUCTURE

function Node(data) {
    this.data = data;
    this.children = [];
}

function Tree() {
    this.root = null;
    this.Name = "";
}

Tree.prototype.add = function (data, toNodeData) {
    var node = new Node(data);
    var parent = toNodeData ? this.findBFS(toNodeData) : null;
    if (parent) {
        parent.children.push(node);
    } else {
        if (!this.root) {
            this.root = node;
        } else {
            return 'Root node is already assigned';
        }
    }
};
Tree.prototype.remove = function (data) {
    if (this.root.data === data) {
        this.root = null;
    }

    var queue = [this.root];
    while (queue.length) {
        var node = queue.shift();
        for (var i = 0; node && i < node.children.length; i++) {
            if (node.children[i].data === data) {
                node.children.splice(i, 1);
            } else {
                queue.push(node.children[i]);
            }
        }
    }
};
Tree.prototype.contains = function (data) {
    return this.findBFS(data) ? true : false;
};
Tree.prototype.findBFS = function (data) {
    var queue = [this.root];
    while (queue.length) {
        var node = queue.shift();
        if (node.data === data) {
            return node;
        }
        for (var i = 0; i < node.children.length; i++) {
            queue.push(node.children[i]);
        }
    }
    return null;
};
Tree.prototype._preOrder = function (node, fn) {
    if (node) {
        if (fn) {
            fn(node);
        }
        for (var i = 0; i < node.children.length; i++) {
            this._preOrder(node.children[i], fn);
        }
    }
};
Tree.prototype._postOrder = function (node, fn) {
    if (node) {
        for (var i = 0; i < node.children.length; i++) {
            this._postOrder(node.children[i], fn);
        }
        if (fn) {
            fn(node);
        }
    }
};
Tree.prototype.traverseDFS = function (fn, method) {
    var current = this.root;
    if (method) {
        this['_' + method](current, fn);
    } else {
        this._preOrder(current, fn);
    }
};
Tree.prototype.traverseBFS = function (fn) {
    var queue = [this.root];
    while (queue.length) {
        var node = queue.shift();
        if (node) {
            if (fn) {
                fn(node);
            }
            for (var i = 0; i < node.children.length; i++) {
                queue.push(node.children[i]);
            }
        }
    }
};
Tree.prototype.print = function () {
    if (!this.root) {
        return console.log('No root node found');
    }
    var newline = new Node('|');
    var queue = [this.root, newline];
    var string = '';
    while (queue.length) {
        var node = queue.shift();
        string += node.data.toString() + ' ';
        if (node === newline && queue.length) {
            queue.push(newline);
        }
        for (var i = 0; i < node.children.length; i++) {
            queue.push(node.children[i]);
        }
    }
    console.log(string.slice(0, -2).trim());
};
Tree.prototype.printByLevel = function () {
    if (!this.root) {
        return console.log('No root node found');
    }
    var newline = new Node('\n');
    var queue = [this.root, newline];
    var string = '';
    while (queue.length) {
        var node = queue.shift();
        string += node.data.toString() + (node.data !== '\n' ? ' ' : '');
        if (node === newline && queue.length) {
            queue.push(newline);
        }
        for (var i = 0; i < node.children.length; i++) {
            queue.push(node.children[i]);
        }
    }
    console.log(string.trim());
};


/// TREEVIEW FUNCTIONS
tree = [];

//Append a tree in the Tree list
function addTreeData(t) {
    tree.push(new Tree());
    tree[tree.length - 1].Name = t.Name;
    if (t.root && t.root.data.name !== "")
        tree[tree.length - 1].root = t.root;
    else
        tree[tree.length - 1].root = null;
}

//Get the entire tree list
function getFullTree() {
    return tree;
}

//Get in the Tree list a tree by its index
function getTree(idx) {
    return tree[idx];
}

//Add a node to the tree[idx] at given node with data
function addNode(idx, node, data) {
    var s = tree[idx].add(data, node);
    return typeof s === "undefined" ? true : false;
}