using System;
using System.Collections.Generic;
namespace WeekTwo
{
    public class HashNode<K, V> 
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public int HashCode;

        public HashNode<K, V> Next;

        public HashNode(K key, V value, int hashCode)
        {
            Key = key;
            Value = value;
            HashCode = hashCode;
        }
    }

    public class HashMap<K, V> 
    {
        private List<HashNode<K, V>> bucket;
        private int numberOfBuckets;
        private int size;

        public HashMap()
        {
            bucket = new List<HashNode<K, V>>();
            numberOfBuckets = 10;
            size = 0;

            for(int i = 0; i < numberOfBuckets; i++)
            {
                bucket.Add(null);
            }
        }

        private int GetBucketIndex(K key)
        {
            int hashCode = GetKeyHashCode(key);
            int index = hashCode % numberOfBuckets; // 5 % 10 = 0.2
            index = index < 0 ? index * -1 : index;
            return index;
        }

        public void Add(K key, V value)
        {
            int bucketIndex = GetBucketIndex(key);
            int hashCode = GetKeyHashCode(key);

            HashNode<K, V> hashNode = bucket[bucketIndex];

            while(hashNode != null)
            {
                if (hashNode.Key.Equals(key) && hashNode.HashCode == hashCode)
                {
                    hashNode.Value = value;
                    return;
                }
                hashNode = hashNode.Next;
            }

            size++;
            hashNode = bucket[bucketIndex];
            
            HashNode<K, V> newNode = new HashNode<K, V>(key, value, hashCode);
            newNode.Next = hashNode;
            bucket[bucketIndex] = newNode;

            if ((1.0 * size) / numberOfBuckets >= 0.7)
            {
                List<HashNode<K, V>> tmp = bucket;
                bucket = new List<HashNode<K, V>>();
                numberOfBuckets *= 2;
                size = 0;

                for(int i = 0; i < numberOfBuckets; i++)
                {
                    bucket.Add(null);
                }

                foreach(var headNode in tmp)
                {
                    var tmpNode = headNode;
                    while(tmpNode != null)
                    {
                        Add(tmpNode.Key, tmpNode.Value);
                        tmpNode = tmpNode.Next;
                    }
                }
            }
        }

        public V Get(K key)
        {
            int bucketIndex = GetBucketIndex(key);
            int hashCode = GetKeyHashCode(key);

            HashNode<K, V> hashNode = bucket[bucketIndex];

            while(hashNode != null)
            {
                if(hashNode.Key.Equals(key) && hashNode.HashCode == hashCode)
                {
                    return hashNode.Value;
                }

                hashNode = hashNode.Next;
            }

            return default(V);
        }

        public V Remove(K key)
        {
            int bucketIndex = GetBucketIndex(key);
            int hashCode = GetKeyHashCode(key);

            HashNode<K, V> hashNode = bucket[bucketIndex];
            HashNode<K, V> previous = null;

            while(hashNode != null)
            {
                if (hashNode.Key.Equals(key) && hashCode == hashNode.HashCode)
                    break;
                
                previous = hashNode;
                hashNode = hashNode.Next;
            }

            if (hashNode == null)
                return default(V);

            size--;

            if (previous != null)
            {
                previous.Next = hashNode.Next;
            }
            else
            {
                bucket[bucketIndex] = hashNode.Next;
            }

            return hashNode.Value;
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return size == 0;
            }
        }

        private int GetKeyHashCode(K key)
        {
            return key.GetHashCode();
        }
    }
}