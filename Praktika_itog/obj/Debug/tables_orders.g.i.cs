﻿#pragma checksum "..\..\tables_orders.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7BFCC3BAC5C2424903795E2B58F51723EE018AC7CD1CE56310B960C3619966A8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Praktika_itog;
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
using System.Windows.Shell;


namespace Praktika_itog {
    
    
    /// <summary>
    /// tables_orders
    /// </summary>
    public partial class tables_orders : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\tables_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridik;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\tables_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\tables_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dobav;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\tables_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izmen;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\tables_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox3;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\tables_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox2;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\tables_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox1;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\tables_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datapick;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Praktika_itog;component/tables_orders.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\tables_orders.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.gridik = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\tables_orders.xaml"
            this.gridik.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.gridik_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.delete = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\tables_orders.xaml"
            this.delete.Click += new System.Windows.RoutedEventHandler(this.delete_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dobav = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\tables_orders.xaml"
            this.dobav.Click += new System.Windows.RoutedEventHandler(this.dobav_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.izmen = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\tables_orders.xaml"
            this.izmen.Click += new System.Windows.RoutedEventHandler(this.izmen_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.combobox3 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.combobox2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.combobox1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.datapick = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

