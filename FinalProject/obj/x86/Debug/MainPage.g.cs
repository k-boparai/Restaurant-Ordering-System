﻿#pragma checksum "C:\Users\Karan\Desktop\C# UWP\Final\FinalProject\FinalProject\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "24E9A95FB426469BC3D0BA59E1819AFAF625E67CB48582BEB34D6FCBD4F88F3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::FinalProject.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj14;
            private global::Windows.UI.Xaml.Controls.ListView obj16;
            private global::Windows.UI.Xaml.Controls.ListView obj24;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj14ItemsSourceDisabled = false;
            private static bool isobj16ItemsSourceDisabled = false;
            private static bool isobj24ItemsSourceDisabled = false;

            public MainPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 30 && columnNumber == 58)
                {
                    isobj14ItemsSourceDisabled = true;
                }
                else if (lineNumber == 43 && columnNumber == 57)
                {
                    isobj16ItemsSourceDisabled = true;
                }
                else if (lineNumber == 64 && columnNumber == 66)
                {
                    isobj24ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 14: // MainPage.xaml line 30
                        this.obj14 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 16: // MainPage.xaml line 43
                        this.obj16 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 24: // MainPage.xaml line 64
                        this.obj24 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::FinalProject.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::FinalProject.MainPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_currentList(obj.currentList, phase);
                        this.Update_shoppingCart(obj.shoppingCart, phase);
                        this.Update_feedbackList(obj.feedbackList, phase);
                    }
                }
            }
            private void Update_currentList(global::System.Collections.ObjectModel.ObservableCollection<global::FinalProject.Models.Product> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 30
                    if (!isobj14ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj14, obj, null);
                    }
                }
            }
            private void Update_shoppingCart(global::System.Collections.ObjectModel.ObservableCollection<global::FinalProject.Models.Product> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 43
                    if (!isobj16ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj16, obj, null);
                    }
                }
            }
            private void Update_feedbackList(global::System.Collections.ObjectModel.ObservableCollection<global::FinalProject.Models.Feedback> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 64
                    if (!isobj24ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj24, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 14
                {
                    this.username = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // MainPage.xaml line 15
                {
                    this.password = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // MainPage.xaml line 16
                {
                    this.login = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.login).Click += this.login_Click;
                }
                break;
            case 5: // MainPage.xaml line 17
                {
                    this.Register = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Register).Click += this.Register_Click;
                }
                break;
            case 6: // MainPage.xaml line 18
                {
                    this.loggedIn = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // MainPage.xaml line 19
                {
                    this.error = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // MainPage.xaml line 20
                {
                    this.logout = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.logout).Click += this.logout_Click;
                }
                break;
            case 9: // MainPage.xaml line 24
                {
                    this.appetizers = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.appetizers).Click += this.appetizers_Click;
                }
                break;
            case 10: // MainPage.xaml line 25
                {
                    this.mains = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.mains).Click += this.mains_Click;
                }
                break;
            case 11: // MainPage.xaml line 26
                {
                    this.sides = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.sides).Click += this.sides_Click;
                }
                break;
            case 12: // MainPage.xaml line 27
                {
                    this.dessert = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.dessert).Click += this.dessert_Click;
                }
                break;
            case 13: // MainPage.xaml line 29
                {
                    this.listLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // MainPage.xaml line 30
                {
                    this.list = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 15: // MainPage.xaml line 42
                {
                    this.cartLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // MainPage.xaml line 43
                {
                    this.cart = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 17: // MainPage.xaml line 55
                {
                    this.subtotal = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // MainPage.xaml line 56
                {
                    this.discount = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // MainPage.xaml line 57
                {
                    this.total = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20: // MainPage.xaml line 58
                {
                    this.checkout = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.checkout).Click += this.checkout_Click;
                }
                break;
            case 21: // MainPage.xaml line 60
                {
                    this.feedback = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.feedback).Click += this.feedback_Click;
                }
                break;
            case 22: // MainPage.xaml line 61
                {
                    this.feedbackBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 23: // MainPage.xaml line 63
                {
                    this.feedbackLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24: // MainPage.xaml line 64
                {
                    this.listOfFeedback = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 25: // MainPage.xaml line 74
                {
                    this.insertName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 26: // MainPage.xaml line 75
                {
                    this.insertPrice = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 27: // MainPage.xaml line 76
                {
                    this.insertButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.insertButton).Click += this.insertButton_Click;
                }
                break;
            case 28: // MainPage.xaml line 77
                {
                    this.deleteButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.deleteButton).Click += this.deleteButton_Click;
                }
                break;
            case 29: // MainPage.xaml line 78
                {
                    this.adminText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 37: // MainPage.xaml line 49
                {
                    global::Windows.UI.Xaml.Controls.Button element37 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element37).Tapped += this.removeFromCart_Tapped;
                }
                break;
            case 42: // MainPage.xaml line 36
                {
                    global::Windows.UI.Xaml.Controls.Button element42 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element42).Tapped += this.addToCart_Tapped;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

