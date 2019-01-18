namespace FacebookVip.Logic.Iterator
{
    //the iterator interface
    public interface IAggregate
    {
        IIterator CreateIterator();
    }
}
