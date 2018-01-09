namespace SimuladorTransacional
{
    public interface ILocks
    {
        string numero { get; set; }
        char recurso { get; set; }
        char tipo { get; set; }
    }
}