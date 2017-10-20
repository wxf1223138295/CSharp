using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 大通杀杀杀
{
    public class crms
    {
        [DllImport("CRMS_UI.dll", EntryPoint = "CRMS_UI")]
        public static extern int CRMS_UI(uint nMsg,
[System.Runtime.InteropServices.InAttribute()]             [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string lpszBaseXml,
[System.Runtime.InteropServices.InAttribute()]             [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string lpszDetailsXml, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.BStr)] ref string pBstrResults);

    }
}
