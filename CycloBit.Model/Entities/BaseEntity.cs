namespace CycloBit.Model.Entities {
    public class BaseEntity<T> where T : struct {
        
        public T Id { get; set; }
    }

    public class BaseEntity {
        public string Id { get; set; }
    }
}