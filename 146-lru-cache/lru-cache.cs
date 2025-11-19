    public class LRUCache
    {
        private readonly Dictionary<int, Node> nodes;
        private readonly int capacity;
        private Node head;
        private Node tail;

        public LRUCache(int capacity)
        {
            head = new Node();
            tail = new Node();
            head.next = tail;
            tail.prev = head;
            this.capacity = capacity;
            nodes = [];
        }

        public int Get(int key)
        {
            if (nodes.TryGetValue(key, out Node node))
            {
                // move this node to head as most recently used
                Node nodePrev = node.prev;
                Node nodeNext = node.next;
                Node headNext = head.next;
                if (node != headNext)
                {
                    nodePrev.next = nodeNext;
                    nodeNext.prev = nodePrev;
                    node.next = headNext;
                    node.prev = head;
                    head.next = node;
                    headNext.prev = node;
                }
                return node.val;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (nodes.TryGetValue(key, out Node node))
            {
                // update and move to head
                node.val = value;
                Get(key);
            }
            else
            {
                // check capacity
                if (nodes.Count >= capacity)
                {
                    // evict LRU from tail: update tail.prev and update
                    Node toOverride = tail.prev;
                    nodes.Remove(toOverride.key);
                    toOverride.key = key;
                    toOverride.val = value;
                    nodes.Add(toOverride.key, toOverride);
                    Get(toOverride.key);
                }
                else
                {
                    // add to head
                    Node newNode = new Node
                    {
                        key = key,
                        val = value,
                    };
                    Node headNext = head.next;
                    nodes.Add(key, newNode);
                    newNode.next = headNext;
                    newNode.prev = head;
                    headNext.prev = newNode;
                    head.next = newNode;
                }
            }
        }
    }

    class Node
    {
        public int key;
        public int val;
        public Node prev;
        public Node next;
    }

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */