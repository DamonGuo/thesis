﻿#pragma checksum "..\..\MinimizedControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AB849B3310CDA81914F6362D64770E18"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4214
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Controls.ContactVisualizations;
using Microsoft.Surface.Presentation.Controls.Primitives;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Displex {
    
    
    /// <summary>
    /// MinimizedControl
    /// </summary>
    public partial class MinimizedControl : Microsoft.Surface.Presentation.Controls.SurfaceUserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\MinimizedControl.xaml"
        internal Microsoft.Surface.Presentation.Controls.SurfaceButton restoreButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MinimizedControl.xaml"
        internal Microsoft.Surface.Presentation.Controls.SurfaceButton closeButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Displex;component/minimizedcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MinimizedControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.restoreButton = ((Microsoft.Surface.Presentation.Controls.SurfaceButton)(target));
            
            #line 16 "..\..\MinimizedControl.xaml"
            this.restoreButton.Click += new System.Windows.RoutedEventHandler(this.restoreButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.closeButton = ((Microsoft.Surface.Presentation.Controls.SurfaceButton)(target));
            
            #line 24 "..\..\MinimizedControl.xaml"
            this.closeButton.Click += new System.Windows.RoutedEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
