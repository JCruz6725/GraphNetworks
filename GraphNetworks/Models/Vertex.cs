namespace GraphNetworks.Models
{
    internal class Vertex
    {
        public required object Name { get; set; }
        public int? Id { get; set; }


        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            if (obj is not Vertex vertex)
                return false;

            if (Id == null)
                return vertex.Name.Equals(Name);

            return vertex.Id == Id;
        }

        // override object.GetHashCode
        public override int GetHashCode() => (Id, Name).GetHashCode();

    }
}
