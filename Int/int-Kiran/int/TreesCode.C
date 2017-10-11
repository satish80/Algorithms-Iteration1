#include<stdio.h>

// -- Structure for the Tree
struct tNode
{
	int data;
	tNode *left;
	tNode *right;
};

// -- function Definitions
void buildTree(tNode **);
tNode *newNode(int data);
void insertTree(tNode **root, int data);
int size(tNode *root);
int maxDepth(tNode *root);
void printTree(tNode *root);
void printTreePost(tNode *root);
int hasSumPath(tNode *root, int sum);
void printPath(tNode *root);


int main(void)
{
	// -- Create the Tree?
	tNode *root;

	root = NULL;

	//buildTree(&root);
	insertTree(&root,2);
	insertTree(&root,3);
	insertTree(&root,1);
	insertTree(&root,6);
	insertTree(&root,10);
	insertTree(&root,1);

	printf("%d,%d,%d",root->data,(root->left)->data,(root->right)->data);

	printf("\n Size is : %d\n",maxDepth(root));

	//printTree(root);
    //printTreePost(root);
    printf("\n---------------------------\n");
    printf("Number of Paths : %d", hasSumPath(root,21));

    printf("\n---------------------------\n");
    printPath(root);
	printf("\n---------------------------\n");
	return(0);
}

int size(tNode *root)
{
	if(root == NULL) return 0;
	else return (1+size(root->left)+size(root->right));
}

int maxDepth(tNode *root)
{
	if(root == NULL) return 0;
	int leftLength = maxDepth(root->left);
	int rightLength = maxDepth(root->right);
	return((leftLength > rightLength)?++leftLength:++rightLength);
}

void insertTree(tNode **root, int data)
{
	if(*root==NULL) *root = newNode(data);
	else
	{
		if((*root)->data > data) insertTree(&((*root)->left), data);
		else insertTree(&((*root)->right),data);
	}
}

void printTree(tNode *root)
{
	if(root == NULL) return;
	printTree(root->left);
	printf("%d ,",root->data);
	printTree(root->right);
}
void printTreePost(tNode *root)
{
	if(root == NULL) return;
	printTreePost(root->left);
	printTreePost(root->right);
	printf("%d ,",root->data);
}

int hasSumPath(tNode *root, int sum)
{
	if(root == NULL)
	{
		// -- i.e We are at the Leaf Node.
		return(sum==0);
	}
	sum-= root->data;
	return(hasSumPath(root->left,sum) || hasSumPath(root->right,sum));

}

void buildTree(tNode **root)
{
	// -- While we get a -1 keep building the node ?
	if((*root) == NULL )
	{
		*root = newNode(2);
		(*root)->left = newNode(1);
		(*root)->right = newNode(3);
	}
}

void printPath(tNode *root, char *pathSoFar)
{
	if(root==NULL)
	{
		printf("%s\n",pathSoFar);
		return;
	}
	int length = strlen(pathSoFar);
	char path[length+

	//printf("%d->",root->data);
	//printPath(root->left);
	//printPath(root->right);
}

tNode *newNode(int data)
{
	tNode *node = (tNode *)malloc(sizeof(tNode));
	node->data = data;
	node->left = NULL;
	node->right = NULL;

	return(node);
}