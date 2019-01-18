namespace FacebookVip.Logic.Iterator
{
    //the iterator aggregate interface
    public interface IIterator
    {
        bool MoveNext();
        object Current { get; } 
        void Reset();
    }
}
