/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RotateRight(ListNode head, int k) {
        if(head==null||k==0) return head;
         List<int> list=new List<int>();
         while(head!=null){
            list.Add(head.val);
            head=head.next;
         }
         k%=list.Count();
         int l=0,r=list.Count()-1;
         while(l<r){
            int value=list[r];
            list[r]=list[l];
            list[l]=value;
            l++;r--;
         }
         l=0;r=k-1;
         while(l<r){
            int value=list[r];
            list[r]=list[l];
            list[l]=value;
            l++;r--;
         }
         l=k;r=list.Count()-1;
         while(l<r){
            int value=list[r];
            list[r]=list[l];
            list[l]=value;
            l++;r--;
         }
         ListNode root=null,current=null;
         foreach(int u in list){
            ListNode tem=new ListNode(u);
            if(root==null){
                root=tem;
                current=tem;
            }
            else{
                current.next=tem;
                current=current.next;
            }
         }
         return root;
    }
}