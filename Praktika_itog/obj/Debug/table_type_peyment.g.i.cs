﻿#pragma checksum "..\..\table_type_peyment.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A4FB6AADEF0CEAFF50969AC5EB10693E8BA0182D9043D16BA237144379C4B1E6"
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
    /// table_type_peyment
    /// </summary>
    public partial class table_type_peyment : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\table_type_peyment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridik;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\table_type_peyment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\table_type_peyment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dobav;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\table_type_peyment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button json;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\table_type_peyment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izmen;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\table_type_peyment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text1;
        
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
            System.Uri resourceLocater = new System.Uri("/Praktika_itog;component/table_type_peyment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\table_type_peyment.xaml"
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
            
            #line 16 "..\..\table_type_peyment.xaml"
            this.gridik.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.gridik_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.delete = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\table_type_peyment.xaml"
            this.delete.Click += new System.Windows.RoutedEventHandler(this.delete_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dobav = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\table_type_peyment.xaml"
            this.dobav.Click += new System.Windows.RoutedEventHandler(this.dobav_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.json = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\table_type_peyment.xaml"
            this.json.Click += new System.Windows.RoutedEventHandler(this.json_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.izmen = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\table_type_peyment.xaml"
            this.izmen.Click += new System.Windows.RoutedEventHandler(this.izmen_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.text1 = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

