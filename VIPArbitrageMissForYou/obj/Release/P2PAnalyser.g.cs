﻿#pragma checksum "..\..\P2PAnalyser.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AA5719CF228BBA1EED94E89D2C5B8A4562BC39B7F8F32EBF45997733214D299C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using VIPArbitrageMissForYou;


namespace VIPArbitrageMissForYou {
    
    
    /// <summary>
    /// P2PAnalyser
    /// </summary>
    public partial class P2PAnalyser : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 78 "..\..\P2PAnalyser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView arbitrageListChoice;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\P2PAnalyser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox arbitrageListExchanges;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\P2PAnalyser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox arbitrageListPair;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\P2PAnalyser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox arbitrageListProfit;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\P2PAnalyser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox arbitrageListPrice;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\P2PAnalyser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textgmail;
        
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
            System.Uri resourceLocater = new System.Uri("/VIPArbitrageMissForYou;component/p2panalyser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\P2PAnalyser.xaml"
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
            
            #line 37 "..\..\P2PAnalyser.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 39 "..\..\P2PAnalyser.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.TipsMainPage);
            
            #line default
            #line hidden
            return;
            case 3:
            this.arbitrageListChoice = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.arbitrageListExchanges = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.arbitrageListPair = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.arbitrageListProfit = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.arbitrageListPrice = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            
            #line 125 "..\..\P2PAnalyser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Makemoney);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 126 "..\..\P2PAnalyser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EmailClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 127 "..\..\P2PAnalyser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnComputerExcel);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 128 "..\..\P2PAnalyser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnComputer);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 129 "..\..\P2PAnalyser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HereAnalyse);
            
            #line default
            #line hidden
            return;
            case 13:
            this.textgmail = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

