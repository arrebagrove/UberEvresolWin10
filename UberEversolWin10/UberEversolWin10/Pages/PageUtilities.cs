using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEversol.Pages
{
    /// <summary>
    /// Content Dialog Enumeration for Save / Cancel
    /// </summary>
    public enum cdClicked
    {
        Save,
        Update,
        Cancel
    }

    /// <summary>
    /// Content Dialog Enumeration
    /// </summary>
    public enum cdResult
    {
        AddSuccess,
        AddFail,
        AddCancel,
        UpdateSuccess,
        UpdateFail,
        UpdateCancel
    }


}
