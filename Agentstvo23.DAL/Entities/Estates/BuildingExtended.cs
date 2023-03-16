using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agentstvo23.DAL.Entities.Estates
{
    public class BuildingExtended
    {
        public int Id { get; set; }
        public int? BuildingId { get; set; }
        [ForeignKey(nameof(BuildingId))]
        public Building? Building { get; set; }

        public Polygon? WKT { get; set; }

    }
}
