namespace Project.Domain.Repository.Base
{
    public interface IGetByKey<T, K>
    {
        T GetByKey(K key);
    }
}
