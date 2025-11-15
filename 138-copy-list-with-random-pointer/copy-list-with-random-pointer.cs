public class Solution {
    public Node CopyRandomList(Node head) {
        if(head==null) return null;
        Node current=head;
        while(current!=null){
            Node newnode=new Node(current.val);
            newnode.next=current.next;
            current.next=newnode;
            current=newnode.next;
        }
        current=head;
        while(current!=null){
            if(current.random!=null){
                current.next.random=current.random.next;
            }
            current=current.next.next;
        }
        Node newhead=head.next;
        current=head;
        Node newcurrent=newhead;
        while(current!=null){
            current.next=newcurrent.next;
            current=current.next;
            if(current!=null){
                newcurrent.next=current.next;
                newcurrent=current.next;
            }
        }
        return newhead;
    }
}