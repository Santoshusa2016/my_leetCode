using System;
public class LinkedList{
    public Node head;
    public class Node{
        public int data;
        public Node nextNode;
        public Node(int value){
            this.data = value;
            this.nextNode = null;
        }
    }

        public void pointerReverse(){
            Node prevNode = null;
            Node currentNode = this.head;
            Node nextNode = this.head;

            while (currentNode != null){
                nextNode = currentNode.nextNode;
                currentNode.nextNode = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            };
            head = prevNode;
            printNode();
        }

        public void callrecurrenceReverse(){
            recurrenceReverse(head);
            printNode();
        }

        void recurrenceReverse(Node currentNode){
            //break condition
            if(currentNode.nextNode == null){
                head = currentNode;
                currentNode.nextNode = null;
                return;
            }
            recurrenceReverse(currentNode.nextNode);
            currentNode.nextNode.nextNode = currentNode;
            currentNode.nextNode = null;
            return;
        }

        void printNode(){
            Node currentNode = head;
            if (currentNode != null)
            {
                while (currentNode != null)
                {
                    Console.WriteLine(currentNode.data);
                    currentNode = currentNode.nextNode; 
                }
            }
        }
    }
