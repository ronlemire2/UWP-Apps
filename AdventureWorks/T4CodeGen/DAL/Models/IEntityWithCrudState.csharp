using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models {
    public interface IEntityWithCrudState {
        CrudState CrudState { get; set; }
    }

    public enum CrudState {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}