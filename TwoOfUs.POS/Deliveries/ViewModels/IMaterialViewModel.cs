using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace TwoOfUs.POS.Deliveries.ViewModels
{
    public interface IMaterialViewModel
    {
        IEnumerable<Material> Materials { get; }
        Material SelectedMaterial { get; set; }
    }
}
