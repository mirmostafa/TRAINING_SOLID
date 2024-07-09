namespace SOLID.ISP;

internal interface IReadRepo<TEntity>
{
    TEntity Get(int id);

    IEnumerable<TEntity> GetAll();
}

internal interface IWriteRepo<TEntity>
{
    void Delete(int id);

    void Insert(TEntity entity);

    void Update(TEntity entity);
}

internal interface IGenericRepo<TEntity> : IReadRepo<TEntity>, IWriteRepo<TEntity>;

file record Person(int Id, string Name);

file class PersonReadService(IReadRepo<Person> repo)
{
    public IEnumerable<Person> GetAll() => repo.GetAll();
}

file class PersonService(IGenericRepo<Person> repo)
{
    public IEnumerable<Person> GetAll() => repo.GetAll();
    public void Insert(Person person) => repo.Insert(person);
}