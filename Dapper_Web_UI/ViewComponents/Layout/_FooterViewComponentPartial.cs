using System;
using Microsoft.AspNetCore.Mvc;



/*

Partial kısmının başka bir kullanım şekli ; 

	 Bu C# kodu, ASP.NET Core MVC uygulamasında bir View Component'ını temsil eder.
	 ViewComponent sınıfından türetilmiş bir sınıftır.
	 ViewComponent'lar, bir sayfanın veya sayfa parçasının belirli bir kısmını temsil eden ve MVC uygulamanız içinde yeniden kullanılabilir parçalar oluşturmanıza olanak tanıyan yapıdır.

	Bu özel ViewComponent olan _HeaderViewComponentPartial, genellikle bir sayfanın üst kısmındaki veya header alanındaki içeriği temsil eden bir parçadır.
	Invoke metodu, _HeaderViewComponentPartial'ı çağıran diğer bileşen veya view tarafından tetiklendiğinde çalıştırılan bir metottur.
	Bu metot, View metodu aracılığıyla bir view döndürerek, bu view'ın içeriğini render etmek üzere kullanılır.

	Kullanımı şu şekildedir:

	_HeaderViewComponentPartial'ı çağırmak için bir view'da veya başka bir ViewComponent içinde şu şekilde kullanabilirsiniz:


		@await Component.InvokeAsync("_HeaderViewComponentPartial")


	_HeaderViewComponentPartial'ın içindeki Invoke metodu, _HeaderViewComponentPartial adlı bir view'ı döndürerek bu view'ın içeriğini render etmek üzere kullanılır.

	Bu tür yapılar, özellikle sayfanın belirli kısımlarını modüler hale getirmek ve kodunuzu daha kolay bakım yapılabilir ve yeniden kullanılabilir hale getirmek için kullanışlıdır.
	Bu örnekte, _HeaderViewComponentPartial header bölümünü temsil eden bir bileşen olarak tanımlanmıştır.


 */


namespace Dapper_Web_UI.ViewComponents.Layout
{
	public class _FooterViewComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

