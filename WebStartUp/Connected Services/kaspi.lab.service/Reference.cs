﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebStartUp.kaspi.lab.service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductDTO", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class ProductDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ProductIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ThumbNailPhotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ThumbNailPhotoFileNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public byte[] ThumbNailPhoto {
            get {
                return this.ThumbNailPhotoField;
            }
            set {
                if ((object.ReferenceEquals(this.ThumbNailPhotoField, value) != true)) {
                    this.ThumbNailPhotoField = value;
                    this.RaisePropertyChanged("ThumbNailPhoto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ThumbNailPhotoFileName {
            get {
                return this.ThumbNailPhotoFileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ThumbNailPhotoFileNameField, value) != true)) {
                    this.ThumbNailPhotoFileNameField = value;
                    this.RaisePropertyChanged("ThumbNailPhotoFileName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CurrentProductDTO", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class CurrentProductDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ProductIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] LargePhotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LargePhotoFileNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        private System.Nullable<int> ModelIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ColorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SizeUnitField;
        
        private System.Nullable<decimal> WeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductLineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StyleField;
        
        private int CountField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ProductNumber {
            get {
                return this.ProductNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNumberField, value) != true)) {
                    this.ProductNumberField = value;
                    this.RaisePropertyChanged("ProductNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public byte[] LargePhoto {
            get {
                return this.LargePhotoField;
            }
            set {
                if ((object.ReferenceEquals(this.LargePhotoField, value) != true)) {
                    this.LargePhotoField = value;
                    this.RaisePropertyChanged("LargePhoto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string LargePhotoFileName {
            get {
                return this.LargePhotoFileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LargePhotoFileNameField, value) != true)) {
                    this.LargePhotoFileNameField = value;
                    this.RaisePropertyChanged("LargePhotoFileName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public System.Nullable<int> ModelID {
            get {
                return this.ModelIDField;
            }
            set {
                if ((this.ModelIDField.Equals(value) != true)) {
                    this.ModelIDField = value;
                    this.RaisePropertyChanged("ModelID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Model {
            get {
                return this.ModelField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelField, value) != true)) {
                    this.ModelField = value;
                    this.RaisePropertyChanged("Model");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string Color {
            get {
                return this.ColorField;
            }
            set {
                if ((object.ReferenceEquals(this.ColorField, value) != true)) {
                    this.ColorField = value;
                    this.RaisePropertyChanged("Color");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string Size {
            get {
                return this.SizeField;
            }
            set {
                if ((object.ReferenceEquals(this.SizeField, value) != true)) {
                    this.SizeField = value;
                    this.RaisePropertyChanged("Size");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string SizeUnit {
            get {
                return this.SizeUnitField;
            }
            set {
                if ((object.ReferenceEquals(this.SizeUnitField, value) != true)) {
                    this.SizeUnitField = value;
                    this.RaisePropertyChanged("SizeUnit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=11)]
        public System.Nullable<decimal> Weight {
            get {
                return this.WeightField;
            }
            set {
                if ((this.WeightField.Equals(value) != true)) {
                    this.WeightField = value;
                    this.RaisePropertyChanged("Weight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string ProductLine {
            get {
                return this.ProductLineField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductLineField, value) != true)) {
                    this.ProductLineField = value;
                    this.RaisePropertyChanged("ProductLine");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string Class {
            get {
                return this.ClassField;
            }
            set {
                if ((object.ReferenceEquals(this.ClassField, value) != true)) {
                    this.ClassField = value;
                    this.RaisePropertyChanged("Class");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string Style {
            get {
                return this.StyleField;
            }
            set {
                if ((object.ReferenceEquals(this.StyleField, value) != true)) {
                    this.StyleField = value;
                    this.RaisePropertyChanged("Style");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=15)]
        public int Count {
            get {
                return this.CountField;
            }
            set {
                if ((this.CountField.Equals(value) != true)) {
                    this.CountField = value;
                    this.RaisePropertyChanged("Count");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="kaspi.lab.service.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Контракт генерации сообщений с именем GetProductListResult из пространства имен http://tempuri.org/ не отмечен как обнуляемый
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProductList", ReplyAction="*")]
        WebStartUp.kaspi.lab.service.GetProductListResponse GetProductList(WebStartUp.kaspi.lab.service.GetProductListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProductList", ReplyAction="*")]
        System.Threading.Tasks.Task<WebStartUp.kaspi.lab.service.GetProductListResponse> GetProductListAsync(WebStartUp.kaspi.lab.service.GetProductListRequest request);
        
        // CODEGEN: Контракт генерации сообщений с именем GetProductResult из пространства имен http://tempuri.org/ не отмечен как обнуляемый
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProduct", ReplyAction="*")]
        WebStartUp.kaspi.lab.service.GetProductResponse GetProduct(WebStartUp.kaspi.lab.service.GetProductRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProduct", ReplyAction="*")]
        System.Threading.Tasks.Task<WebStartUp.kaspi.lab.service.GetProductResponse> GetProductAsync(WebStartUp.kaspi.lab.service.GetProductRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Pages", ReplyAction="*")]
        int Pages();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Pages", ReplyAction="*")]
        System.Threading.Tasks.Task<int> PagesAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetProductListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetProductList", Namespace="http://tempuri.org/", Order=0)]
        public WebStartUp.kaspi.lab.service.GetProductListRequestBody Body;
        
        public GetProductListRequest() {
        }
        
        public GetProductListRequest(WebStartUp.kaspi.lab.service.GetProductListRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetProductListRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int PageNum;
        
        public GetProductListRequestBody() {
        }
        
        public GetProductListRequestBody(int PageNum) {
            this.PageNum = PageNum;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetProductListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetProductListResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebStartUp.kaspi.lab.service.GetProductListResponseBody Body;
        
        public GetProductListResponse() {
        }
        
        public GetProductListResponse(WebStartUp.kaspi.lab.service.GetProductListResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetProductListResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WebStartUp.kaspi.lab.service.ProductDTO[] GetProductListResult;
        
        public GetProductListResponseBody() {
        }
        
        public GetProductListResponseBody(WebStartUp.kaspi.lab.service.ProductDTO[] GetProductListResult) {
            this.GetProductListResult = GetProductListResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetProductRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetProduct", Namespace="http://tempuri.org/", Order=0)]
        public WebStartUp.kaspi.lab.service.GetProductRequestBody Body;
        
        public GetProductRequest() {
        }
        
        public GetProductRequest(WebStartUp.kaspi.lab.service.GetProductRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetProductRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int id;
        
        public GetProductRequestBody() {
        }
        
        public GetProductRequestBody(int id) {
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetProductResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetProductResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebStartUp.kaspi.lab.service.GetProductResponseBody Body;
        
        public GetProductResponse() {
        }
        
        public GetProductResponse(WebStartUp.kaspi.lab.service.GetProductResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetProductResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WebStartUp.kaspi.lab.service.CurrentProductDTO GetProductResult;
        
        public GetProductResponseBody() {
        }
        
        public GetProductResponseBody(WebStartUp.kaspi.lab.service.CurrentProductDTO GetProductResult) {
            this.GetProductResult = GetProductResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : WebStartUp.kaspi.lab.service.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<WebStartUp.kaspi.lab.service.WebService1Soap>, WebStartUp.kaspi.lab.service.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebStartUp.kaspi.lab.service.GetProductListResponse WebStartUp.kaspi.lab.service.WebService1Soap.GetProductList(WebStartUp.kaspi.lab.service.GetProductListRequest request) {
            return base.Channel.GetProductList(request);
        }
        
        public WebStartUp.kaspi.lab.service.ProductDTO[] GetProductList(int PageNum) {
            WebStartUp.kaspi.lab.service.GetProductListRequest inValue = new WebStartUp.kaspi.lab.service.GetProductListRequest();
            inValue.Body = new WebStartUp.kaspi.lab.service.GetProductListRequestBody();
            inValue.Body.PageNum = PageNum;
            WebStartUp.kaspi.lab.service.GetProductListResponse retVal = ((WebStartUp.kaspi.lab.service.WebService1Soap)(this)).GetProductList(inValue);
            return retVal.Body.GetProductListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebStartUp.kaspi.lab.service.GetProductListResponse> WebStartUp.kaspi.lab.service.WebService1Soap.GetProductListAsync(WebStartUp.kaspi.lab.service.GetProductListRequest request) {
            return base.Channel.GetProductListAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebStartUp.kaspi.lab.service.GetProductListResponse> GetProductListAsync(int PageNum) {
            WebStartUp.kaspi.lab.service.GetProductListRequest inValue = new WebStartUp.kaspi.lab.service.GetProductListRequest();
            inValue.Body = new WebStartUp.kaspi.lab.service.GetProductListRequestBody();
            inValue.Body.PageNum = PageNum;
            return ((WebStartUp.kaspi.lab.service.WebService1Soap)(this)).GetProductListAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebStartUp.kaspi.lab.service.GetProductResponse WebStartUp.kaspi.lab.service.WebService1Soap.GetProduct(WebStartUp.kaspi.lab.service.GetProductRequest request) {
            return base.Channel.GetProduct(request);
        }
        
        public WebStartUp.kaspi.lab.service.CurrentProductDTO GetProduct(int id) {
            WebStartUp.kaspi.lab.service.GetProductRequest inValue = new WebStartUp.kaspi.lab.service.GetProductRequest();
            inValue.Body = new WebStartUp.kaspi.lab.service.GetProductRequestBody();
            inValue.Body.id = id;
            WebStartUp.kaspi.lab.service.GetProductResponse retVal = ((WebStartUp.kaspi.lab.service.WebService1Soap)(this)).GetProduct(inValue);
            return retVal.Body.GetProductResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebStartUp.kaspi.lab.service.GetProductResponse> WebStartUp.kaspi.lab.service.WebService1Soap.GetProductAsync(WebStartUp.kaspi.lab.service.GetProductRequest request) {
            return base.Channel.GetProductAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebStartUp.kaspi.lab.service.GetProductResponse> GetProductAsync(int id) {
            WebStartUp.kaspi.lab.service.GetProductRequest inValue = new WebStartUp.kaspi.lab.service.GetProductRequest();
            inValue.Body = new WebStartUp.kaspi.lab.service.GetProductRequestBody();
            inValue.Body.id = id;
            return ((WebStartUp.kaspi.lab.service.WebService1Soap)(this)).GetProductAsync(inValue);
        }
        
        public int Pages() {
            return base.Channel.Pages();
        }
        
        public System.Threading.Tasks.Task<int> PagesAsync() {
            return base.Channel.PagesAsync();
        }
    }
}
