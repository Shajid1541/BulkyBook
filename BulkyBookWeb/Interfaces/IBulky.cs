namespace BulkyBookWeb.Interfaces
{
    public interface IBulky<Type, ID, Ret>
    {
        Task<Ret> Create(Type type);

        Task<List<Ret>> GetAll();

        Task<Type> Read(ID iD);

        Task<Ret> Update(Type type);

        Task<bool> Delete(ID type);

    }
}
