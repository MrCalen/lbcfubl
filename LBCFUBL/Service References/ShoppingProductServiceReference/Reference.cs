﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LBCFUBL.ShoppingProductServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Shopping", Namespace="http://schemas.datacontract.org/2004/07/LBCFUBL_WCF.DBO")]
    [System.SerializableAttribute()]
    public partial class Shopping : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.Shopping_Product[] Shopping_ProductField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.Shopping_Product[] Shopping_Product {
            get {
                return this.Shopping_ProductField;
            }
            set {
                if ((object.ReferenceEquals(this.Shopping_ProductField, value) != true)) {
                    this.Shopping_ProductField = value;
                    this.RaisePropertyChanged("Shopping_Product");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Shopping_Product", Namespace="http://schemas.datacontract.org/2004/07/LBCFUBL_WCF.DBO")]
    [System.SerializableAttribute()]
    public partial class Shopping_Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.Product ProductField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.Shopping ShoppingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid id_productField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid id_shoppingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.Product Product {
            get {
                return this.ProductField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductField, value) != true)) {
                    this.ProductField = value;
                    this.RaisePropertyChanged("Product");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.Shopping Shopping {
            get {
                return this.ShoppingField;
            }
            set {
                if ((object.ReferenceEquals(this.ShoppingField, value) != true)) {
                    this.ShoppingField = value;
                    this.RaisePropertyChanged("Shopping");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid id_product {
            get {
                return this.id_productField;
            }
            set {
                if ((this.id_productField.Equals(value) != true)) {
                    this.id_productField = value;
                    this.RaisePropertyChanged("id_product");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid id_shopping {
            get {
                return this.id_shoppingField;
            }
            set {
                if ((this.id_shoppingField.Equals(value) != true)) {
                    this.id_shoppingField = value;
                    this.RaisePropertyChanged("id_shopping");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number {
            get {
                return this.numberField;
            }
            set {
                if ((this.numberField.Equals(value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/LBCFUBL_WCF.DBO")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.Purchase[] PurchasesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.Shopping_Product[] Shopping_ProductField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double cost_with_marginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double cost_without_marginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.Purchase[] Purchases {
            get {
                return this.PurchasesField;
            }
            set {
                if ((object.ReferenceEquals(this.PurchasesField, value) != true)) {
                    this.PurchasesField = value;
                    this.RaisePropertyChanged("Purchases");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.Shopping_Product[] Shopping_Product {
            get {
                return this.Shopping_ProductField;
            }
            set {
                if ((object.ReferenceEquals(this.Shopping_ProductField, value) != true)) {
                    this.Shopping_ProductField = value;
                    this.RaisePropertyChanged("Shopping_Product");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double cost_with_margin {
            get {
                return this.cost_with_marginField;
            }
            set {
                if ((this.cost_with_marginField.Equals(value) != true)) {
                    this.cost_with_marginField = value;
                    this.RaisePropertyChanged("cost_with_margin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double cost_without_margin {
            get {
                return this.cost_without_marginField;
            }
            set {
                if ((this.cost_without_marginField.Equals(value) != true)) {
                    this.cost_without_marginField = value;
                    this.RaisePropertyChanged("cost_without_margin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.descriptionField, value) != true)) {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Purchase", Namespace="http://schemas.datacontract.org/2004/07/LBCFUBL_WCF.DBO")]
    [System.SerializableAttribute()]
    public partial class Purchase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.Product ProductField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.User UserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid id_prodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string loginField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.Product Product {
            get {
                return this.ProductField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductField, value) != true)) {
                    this.ProductField = value;
                    this.RaisePropertyChanged("Product");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.User User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid id_prod {
            get {
                return this.id_prodField;
            }
            set {
                if ((this.id_prodField.Equals(value) != true)) {
                    this.id_prodField = value;
                    this.RaisePropertyChanged("id_prod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string login {
            get {
                return this.loginField;
            }
            set {
                if ((object.ReferenceEquals(this.loginField, value) != true)) {
                    this.loginField = value;
                    this.RaisePropertyChanged("login");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/LBCFUBL_WCF.DBO")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.Account[] AccountsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.Purchase[] PurchasesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string loginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int roleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.Account[] Accounts {
            get {
                return this.AccountsField;
            }
            set {
                if ((object.ReferenceEquals(this.AccountsField, value) != true)) {
                    this.AccountsField = value;
                    this.RaisePropertyChanged("Accounts");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.Purchase[] Purchases {
            get {
                return this.PurchasesField;
            }
            set {
                if ((object.ReferenceEquals(this.PurchasesField, value) != true)) {
                    this.PurchasesField = value;
                    this.RaisePropertyChanged("Purchases");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string login {
            get {
                return this.loginField;
            }
            set {
                if ((object.ReferenceEquals(this.loginField, value) != true)) {
                    this.loginField = value;
                    this.RaisePropertyChanged("login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int role {
            get {
                return this.roleField;
            }
            set {
                if ((this.roleField.Equals(value) != true)) {
                    this.roleField = value;
                    this.RaisePropertyChanged("role");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Account", Namespace="http://schemas.datacontract.org/2004/07/LBCFUBL_WCF.DBO")]
    [System.SerializableAttribute()]
    public partial class Account : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LBCFUBL.ShoppingProductServiceReference.User UserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double argentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string loginField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LBCFUBL.ShoppingProductServiceReference.User User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double argent {
            get {
                return this.argentField;
            }
            set {
                if ((this.argentField.Equals(value) != true)) {
                    this.argentField = value;
                    this.RaisePropertyChanged("argent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string login {
            get {
                return this.loginField;
            }
            set {
                if ((object.ReferenceEquals(this.loginField, value) != true)) {
                    this.loginField = value;
                    this.RaisePropertyChanged("login");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ShoppingProductServiceReference.IShoppingProductService")]
    public interface IShoppingProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingProductService/GetShopping_ProductForShoppingAndProdu" +
            "ct", ReplyAction="http://tempuri.org/IShoppingProductService/GetShopping_ProductForShoppingAndProdu" +
            "ctResponse")]
        LBCFUBL.ShoppingProductServiceReference.Shopping_Product GetShopping_ProductForShoppingAndProduct(LBCFUBL.ShoppingProductServiceReference.Shopping shopping, LBCFUBL.ShoppingProductServiceReference.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingProductService/GetShopping_ProductForShoppingAndProdu" +
            "ct", ReplyAction="http://tempuri.org/IShoppingProductService/GetShopping_ProductForShoppingAndProdu" +
            "ctResponse")]
        System.Threading.Tasks.Task<LBCFUBL.ShoppingProductServiceReference.Shopping_Product> GetShopping_ProductForShoppingAndProductAsync(LBCFUBL.ShoppingProductServiceReference.Shopping shopping, LBCFUBL.ShoppingProductServiceReference.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingProductService/GetShopping_ProductsForShopping", ReplyAction="http://tempuri.org/IShoppingProductService/GetShopping_ProductsForShoppingRespons" +
            "e")]
        LBCFUBL.ShoppingProductServiceReference.Shopping_Product[] GetShopping_ProductsForShopping(LBCFUBL.ShoppingProductServiceReference.Shopping shopping);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingProductService/GetShopping_ProductsForShopping", ReplyAction="http://tempuri.org/IShoppingProductService/GetShopping_ProductsForShoppingRespons" +
            "e")]
        System.Threading.Tasks.Task<LBCFUBL.ShoppingProductServiceReference.Shopping_Product[]> GetShopping_ProductsForShoppingAsync(LBCFUBL.ShoppingProductServiceReference.Shopping shopping);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingProductService/CreateShopping_Product", ReplyAction="http://tempuri.org/IShoppingProductService/CreateShopping_ProductResponse")]
        void CreateShopping_Product(LBCFUBL.ShoppingProductServiceReference.Product product, LBCFUBL.ShoppingProductServiceReference.Shopping shopping, int number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingProductService/CreateShopping_Product", ReplyAction="http://tempuri.org/IShoppingProductService/CreateShopping_ProductResponse")]
        System.Threading.Tasks.Task CreateShopping_ProductAsync(LBCFUBL.ShoppingProductServiceReference.Product product, LBCFUBL.ShoppingProductServiceReference.Shopping shopping, int number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingProductService/DeleteShopping_Product", ReplyAction="http://tempuri.org/IShoppingProductService/DeleteShopping_ProductResponse")]
        bool DeleteShopping_Product(LBCFUBL.ShoppingProductServiceReference.Shopping shopping, LBCFUBL.ShoppingProductServiceReference.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingProductService/DeleteShopping_Product", ReplyAction="http://tempuri.org/IShoppingProductService/DeleteShopping_ProductResponse")]
        System.Threading.Tasks.Task<bool> DeleteShopping_ProductAsync(LBCFUBL.ShoppingProductServiceReference.Shopping shopping, LBCFUBL.ShoppingProductServiceReference.Product product);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IShoppingProductServiceChannel : LBCFUBL.ShoppingProductServiceReference.IShoppingProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ShoppingProductServiceClient : System.ServiceModel.ClientBase<LBCFUBL.ShoppingProductServiceReference.IShoppingProductService>, LBCFUBL.ShoppingProductServiceReference.IShoppingProductService {
        
        public ShoppingProductServiceClient() {
        }
        
        public ShoppingProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ShoppingProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShoppingProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShoppingProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public LBCFUBL.ShoppingProductServiceReference.Shopping_Product GetShopping_ProductForShoppingAndProduct(LBCFUBL.ShoppingProductServiceReference.Shopping shopping, LBCFUBL.ShoppingProductServiceReference.Product product) {
            return base.Channel.GetShopping_ProductForShoppingAndProduct(shopping, product);
        }
        
        public System.Threading.Tasks.Task<LBCFUBL.ShoppingProductServiceReference.Shopping_Product> GetShopping_ProductForShoppingAndProductAsync(LBCFUBL.ShoppingProductServiceReference.Shopping shopping, LBCFUBL.ShoppingProductServiceReference.Product product) {
            return base.Channel.GetShopping_ProductForShoppingAndProductAsync(shopping, product);
        }
        
        public LBCFUBL.ShoppingProductServiceReference.Shopping_Product[] GetShopping_ProductsForShopping(LBCFUBL.ShoppingProductServiceReference.Shopping shopping) {
            return base.Channel.GetShopping_ProductsForShopping(shopping);
        }
        
        public System.Threading.Tasks.Task<LBCFUBL.ShoppingProductServiceReference.Shopping_Product[]> GetShopping_ProductsForShoppingAsync(LBCFUBL.ShoppingProductServiceReference.Shopping shopping) {
            return base.Channel.GetShopping_ProductsForShoppingAsync(shopping);
        }
        
        public void CreateShopping_Product(LBCFUBL.ShoppingProductServiceReference.Product product, LBCFUBL.ShoppingProductServiceReference.Shopping shopping, int number) {
            base.Channel.CreateShopping_Product(product, shopping, number);
        }
        
        public System.Threading.Tasks.Task CreateShopping_ProductAsync(LBCFUBL.ShoppingProductServiceReference.Product product, LBCFUBL.ShoppingProductServiceReference.Shopping shopping, int number) {
            return base.Channel.CreateShopping_ProductAsync(product, shopping, number);
        }
        
        public bool DeleteShopping_Product(LBCFUBL.ShoppingProductServiceReference.Shopping shopping, LBCFUBL.ShoppingProductServiceReference.Product product) {
            return base.Channel.DeleteShopping_Product(shopping, product);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteShopping_ProductAsync(LBCFUBL.ShoppingProductServiceReference.Shopping shopping, LBCFUBL.ShoppingProductServiceReference.Product product) {
            return base.Channel.DeleteShopping_ProductAsync(shopping, product);
        }
    }
}