namespace Models
{
    /// <summary>
    /// Basic inteface for all entities in the db
    /// </summary>
    public interface IIdentifieble
    {
        long Id { get; set; }
    }
}