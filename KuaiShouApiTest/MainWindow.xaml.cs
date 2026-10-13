using DDX.KuaiShouOpen.Requests;
using DDX.KuaiShouOpen.Services;
using KuaiShouApiTest.Models;
using Newtonsoft.Json;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KuaiShouApiTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowView _viewModel = new WindowView();

        private readonly IKuaiShouService _service;
        public MainWindow(IKuaiShouService service)
        {
            _service = service;

            InitializeComponent();

            DataContext = _viewModel;

            LoadConfig();
            InitApiList();

            App.HttpRequest = SetApiReq;
            App.HttpResponse = SetApiRes;
        }
        private void SetApiReq(string msg)
        {
            this._viewModel.ApiReq = msg;
        }
        private void SetApiRes(string msg)
        { 
            this._viewModel.ApiRes = msg;
        }
        private void LoadConfig()
        {
            var str = JsonConvert.SerializeObject(App.KuaiShouConfig);
            this._viewModel.ApiConfig = str;
        }

        private void InitApiList()
        {
            var list = new ObservableCollection<SelectApiModel>();
            list.Add(new SelectApiModel("请选择", null));
            list.Add(new SelectApiModel("获取Token", "AccessToken"));
            list.Add(new SelectApiModel("刷新Token", "RefreshToken"));
            list.Add(new SelectApiModel("门店列表", "ShopPoiQuery"));
            list.Add(new SelectApiModel("商品列表", "ItemListBatchQuery"));
            list.Add(new SelectApiModel("验券准备", "CertificatePrepare"));
            list.Add(new SelectApiModel("验券", "CertificateVerify"));
            list.Add(new SelectApiModel("撤销撤销", "CertificateCancel"));

            this._viewModel.ApiModels = list;
        }


        private void Com_Api_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0)
                return;

            var item = e.AddedItems[0] as SelectApiModel;

            SetApiParm(item);

            this._viewModel.SelectApiModel = item;
            this._viewModel.ApiReq = null;
            this._viewModel.ApiRes = null;
            this._viewModel.ApiOut = null;
        }

        private void SetApiParm(SelectApiModel model)
        {
            switch (model.ApiKey)
            {
                case "AccessToken":
                    this._viewModel.ApiParm = JsonConvert.SerializeObject(new OAuth2AccessTokenReq { AppId = App.KuaiShouConfig.AppId, AppSecret = App.KuaiShouConfig.AppSecret });
                    break;
                case "RefreshToken":
                    this._viewModel.ApiParm = JsonConvert.SerializeObject(new OAuth2RefreshTokenReq { AppId = App.KuaiShouConfig.AppId, AppSecret = App.KuaiShouConfig.AppSecret, RefreshToken = App.KuaiShouConfig.RefreshToken });
                    break;
                case "ShopPoiQuery":
                    this._viewModel.ApiParm = JsonConvert.SerializeObject(new ShopPoiQueryReq { });
                    break;
                case "ItemListBatchQuery":
                    this._viewModel.ApiParm = JsonConvert.SerializeObject(new ItemListBatchQueryReq { });
                    break;
                case "CertificatePrepare":
                    this._viewModel.ApiParm = JsonConvert.SerializeObject(new CertificatePrepareReq { });
                    break;
                case "CertificateVerify":
                    this._viewModel.ApiParm = JsonConvert.SerializeObject(new CertificateVerifyReq { CodeWithBizInfo = new CodeWithBizInfo(), CodeWithTimeList = new List<CodeWithTimeItem>() });
                    break;
                case "CertificateCancel":
                    this._viewModel.ApiParm = JsonConvert.SerializeObject(new CertificateCancelReq { CodeWithBizCancelInfo = new CodeWithBizCancelInfo() });
                    break;
                default:
                    this._viewModel.ApiParm = "";
                    break;
            }
        }

        private void Btn_Refsh_Click(object sender, RoutedEventArgs e)
        {
            LoadConfig();
        }
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            App.KuaiShouConfig = JsonConvert.DeserializeObject<KuaiShouConfig>(this._viewModel.ApiConfig);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this._viewModel.SelectApiModel == null)
                return;

            ApiInvoik1();
        }
        private Task ApiInvoik1()
        {
            return ApiInvoik();
        }
        private async Task ApiInvoik()
        {
            this.Btn_Exec.IsEnabled = false;
            try
            {
                switch (this._viewModel.SelectApiModel.ApiKey)
                {
                    case "AccessToken":
                        {
                            var req = JsonConvert.DeserializeObject<OAuth2AccessTokenReq>(this._viewModel.ApiParm);
                            var result = await _service.GetAccessToken(req.Code);
                            App.KuaiShouConfig.AccessToken = result.AccessToken;
                            App.KuaiShouConfig.RefreshToken = result.RefreshToken;
                            LoadConfig();
                        }
                        break;
                    case "RefreshToken":
                        {
                            var req = JsonConvert.DeserializeObject<OAuth2RefreshTokenReq>(this._viewModel.ApiParm);
                            var result = await _service.GetRefreshToken(req.RefreshToken);
                            App.KuaiShouConfig.AccessToken = result.AccessToken;
                            App.KuaiShouConfig.RefreshToken = result.RefreshToken;
                            LoadConfig();
                        }
                        break;
                    case "ShopPoiQuery":
                        {
                            var req = JsonConvert.DeserializeObject<ShopPoiQueryReq>(this._viewModel.ApiParm);
                            var result = await _service.ShopQuery(req);
                            this._viewModel.ApiOut = JsonConvert.SerializeObject(result);
                        }
                        break;
                    case "ItemListBatchQuery":
                        {
                            var req = JsonConvert.DeserializeObject<ItemListBatchQueryReq>(this._viewModel.ApiParm);
                            var result = await _service.ItemQuery(req);
                            this._viewModel.ApiOut = JsonConvert.SerializeObject(result);
                        }
                        break;
                    case "CertificatePrepare":
                        {
                            var req = JsonConvert.DeserializeObject<CertificatePrepareReq>(this._viewModel.ApiParm);
                            var result = await _service.CertificatePrepare(req);
                            this._viewModel.ApiOut = JsonConvert.SerializeObject(result);
                        }
                        break;
                    case "CertificateVerify":
                        {
                            var req = JsonConvert.DeserializeObject<CertificateVerifyReq>(this._viewModel.ApiParm);
                            var result = await _service.CertificateVerify(req);
                            this._viewModel.ApiOut = JsonConvert.SerializeObject(result);
                        }
                        break;
                    case "CertificateCancel":
                        {
                            var req = JsonConvert.DeserializeObject<CertificateCancelReq>(this._viewModel.ApiParm);
                            var result = await _service.CertificateCancel(req);
                            this._viewModel.ApiOut = JsonConvert.SerializeObject(result);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                this._viewModel.ApiOut = ex.Message;
            }
            finally
            {
                this.Btn_Exec.IsEnabled = true;
            }
        }
    }


    [AddINotifyPropertyChangedInterface]
    public class WindowView
    {
        public string ApiConfig { get; set; }
        public ObservableCollection<SelectApiModel> ApiModels { get; set; } = new ObservableCollection<SelectApiModel>();
        public string ApiParm { get; set; }
        public string ApiReq { get; set; }
        public string ApiRes { get; set; }
        public string ApiOut { get; set; }

        public SelectApiModel SelectApiModel { get; set; }
    }
}