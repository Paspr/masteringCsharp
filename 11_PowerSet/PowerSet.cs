using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class PowerSet<T>
    {
        public List<T> container;

        public PowerSet()
        {
            container = new List<T>(); // inner storage for the elements
        }

        public int Size()
        {
            // number of the elements in the set
            return container.Count;
        }

        public void Put(T value)
        {
            // put value in set
            if (!container.Contains(value))
            { 
                container.Add(value);
            }

        }

        public bool Get(T value)
        {
            // returns true if value is in set,
            if (container.Contains(value))
            {
                return true;
            }
            
            else
            {
                return false;
            }
            
        }

        public bool Remove(T value)
        {
            // returns true if value has been deleted
            if (container.Remove(value))
            {
                return true;
            }
            
            else
            {
                return false;
            }
            
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // return the intersection of the current set and set2
            PowerSet<T> intersect = new PowerSet<T>();
            for (int i=0; i<container.Count; i++)
            {
                if (set2.Get(container[i]))
                {
                    intersect.Put(container[i]);
                }
            }
            return intersect;

        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // return the union of the current set and set2
            PowerSet<T> union = new PowerSet<T>();
            for (int i = 0; i < container.Count; i++)
            {
                union.Put(container[i]);
            }
            for (int i = 0; i < set2.container.Count; i++)
            {
                union.Put(set2.container[i]);
            }
            return union;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // difference of the current set and set2
            PowerSet<T> diff = new PowerSet<T>();
            for (int i = 0; i < container.Count; i++)
            {
                if (!set2.Get(container[i]))
                {
                    diff.Put(container[i]);
                }
            }
            return diff;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            // returns true 
            // if set2 is a subset of the current set
            bool issubset = true;
            for (int i = 0; i < set2.container.Count; i++)
            {
                if (!container.Contains(set2.container[i])) issubset = false;
            }
            if (issubset)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }
    }
}