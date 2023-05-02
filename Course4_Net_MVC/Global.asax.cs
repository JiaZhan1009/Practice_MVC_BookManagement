using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Course4_Net_MVC
{
    //public class MvcApplication : System.Web.HttpApplication
    public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication
    {
        //�o�O ASP.NET MVC �M�פ� Global.asax.cs �ɮת����e�C���ɮשw�q�F MvcApplication ���O�A���~�Ӧ� System.Web.HttpApplication ���O�C

        //MvcApplication ���O���w�q�F�@�ӦW�� Application_Start ����k�C�Ӥ�k�b���ε{���ҰʮɳQ�եΤ@���A�Ω�������ε{������l�Ƥu�@�C

        // �b���ε{���Ұʮɰ���A��l�ƩҦ��]�w�B���ѩM���j�]�]�w
        protected void Application_Start()
        {
            // ���U�M�פ��w�q���Ҧ��ϰ�(Area)�C�ϰ�O�@�ز�´�����M�ת��覡�A�����\�z�N���P�\��Ҳժ�����B���ϩM�ҫ����զb���P���ϰ줤�C
            AreaRegistration.RegisterAllAreas();

            // ���U�����z�ﾹ�C�z�ﾹ�O�@�إi�H�b���汱��ʧ@���e�Τ���B�檺�{���X�A���i�H�Ω������v�B���~�B�z�B��x�O�����ާ@�C
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // ���U���ѡC���ѬO�@�رN URL �M�g�챱��ʧ@���覡�C�z�i�H�b RouteConfig.cs �ɮפ��w�q���ѳW�h�C
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // ���U���j�](Bundle)�C���j�]�O�@�رN�h�� CSS �� JavaScript �ɮצX�֦��@���ɮת��覡�A���i�H��� HTTP �ШD���ƶq�A���������[���t�סC
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

}

