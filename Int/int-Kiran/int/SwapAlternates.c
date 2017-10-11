/*
polymorphism is the ability of one
method to have different  behavior depending on the type of object it is being called
on or the type of object  being passed as a parameter.

  For example, if we defined our own "MyInteger" class
and wanted to define an "add" method for it (to add that integer with another  number), we would want the following code to work:

MyInteger int1 = new MyInteger(5); MyInteger int2 = new MyInteger(7);
MyFloat float1 = new MyFloat(3.14); MyDouble doub1 = new MyDouble(2.71);
print(int1.add(int2)); print(int1.add(float1)); print(int1.add(doub1));
*/

#include<stdio.h>

struct Node
{
	int data;
	Node *next;
};

void printList(Node *head);
Node *buildtree(void);
Node *SwapAlternate(Node *head);

int main(void)
{
	Node *head = buildtree();
	printList(head);
	head = SwapAlternate(head);
	printList(head);
	return 0;
}

Node *SwapAlternate(Node *head)
{

   Node *newNode = NULL;
   Node *prev = NULL;
   while(head != NULL && head->next != NULL)
   {
	   if(newNode == NULL) newNode = head->next;
	   Node *temp = head->next;
	   head->next=temp->next;
	   temp->next=head;

	   if(prev!=NULL) prev->next=temp;
	   prev=head;
	   //-- move ahead
	   head=head->next;
   }
   return(newNode);

}
void printList(Node *head)
{
	printf("\n");
	while(head != NULL)
	{
		printf("%d->",head->data);
		head = head->next;
	}
	printf("\n");
}

Node *buildtree(void)
{
	int a[] = {1,2,1,2,1,2,1,2,1,2};
	int i =0;
	Node *head = NULL;
	for(i=0;i<10;i++)
	{
		Node *temp = (Node *)malloc(sizeof(Node));
		temp->data =a[i];
		temp->next = head;
		head = temp;

	}
	return (head);
}