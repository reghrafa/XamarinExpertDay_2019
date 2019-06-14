// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DwxSpeaker.Ios
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCFNetwork { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblManaged { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNSUrl { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblCFNetwork != null) {
                lblCFNetwork.Dispose ();
                lblCFNetwork = null;
            }

            if (lblManaged != null) {
                lblManaged.Dispose ();
                lblManaged = null;
            }

            if (lblNSUrl != null) {
                lblNSUrl.Dispose ();
                lblNSUrl = null;
            }
        }
    }
}