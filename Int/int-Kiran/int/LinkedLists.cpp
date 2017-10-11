#include<stdio.h>


struct Node
{
	int data;
	Node *next;
};

Node *buildList();
void printList(Node *head);
void reverseListNormal(Node **head);
Node* reverseList(Node* p);

int main(void)
{
Node *head = buildList();
cout<<"---------------"<<endl;
printList(head);

reverseListNormal(&head);
cout<<"---------------"<<endl;
printList(head);

head = reverseList(head);
cout<<"---------------"<<endl;
printList(head);
return 0;
}

Node *buildList()
{
	Node *headNode;
	headNode = NULL;
	int i;
	for(i=0;i<10;i++)
	{
		Node *temp = (Node *)malloc(sizeof(Node));
		temp->data = i;
		temp->next = headNode;
		headNode = temp;
	}
cout<<headNode<<endl;
	return(headNode);
}

void printList(Node *head)
{
	while(head != NULL)
	{
		printf("%d\n",head->data);
		head = head->next;
	}
}

Node* reverseList(Node* p)
{
	if(p==NULL) return NULL;
	Node *n = p->next;
	p->next = NULL;
	Node *r = reverseList(n);
	if(r==NULL) return p;
	n->next = p;
	return(r);
}


void reverseListNormal(Node **head)
{
	Node *temp;
	Node *current;
	Node *previous;
	if(*head == NULL) return;
	temp = (*head)->next;
	current = *head;
	current->next = NULL;
	while(temp != NULL)
	{
		previous = current;
		current = temp;
		temp = temp->next;

		current->next = previous;
	}

	*head = current;

}