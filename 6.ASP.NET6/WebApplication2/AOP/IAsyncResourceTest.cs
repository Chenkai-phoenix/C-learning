using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
/*----IAsyncResourceFilter(异步版)
 * 
1.使用：
     step1：声明一个新类继承: Attribute, IAsyncResourceFilter并重写IResourceFilter接口
     step2:在需要的函数前标记[新类名]
例如：
	 [IAsyncResourceFilterTest]
      void Test();
2.作用：
（1）定义一个缓存区域
（2）当请求时，根据缓存标识判断，若有缓存，返回缓存值；若没有缓存， ResourceExecutedContext resource = await next.Invoke();
将resource.Result的值存到缓存
3.通过一个方法实现
 */


namespace WebApplication2.AOP
{
    public class IAnsycResourceFilterTest : Attribute, IAsyncResourceFilter
    {
        private Dictionary<string, object> Cache = new Dictionary<string, object>(); //创建一个缓存
        // 当XXXX资源执行时
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {

            string key = context.HttpContext.Request.Path.ToString();
            if (Cache.ContainsKey(key))
            {
                //有缓存，保存缓存的值；（只要context.Result赋值完就会return）
                context.Result = (IActionResult)Cache[key];
            }
            else
            {
                // 若没有缓存
                ResourceExecutedContext resource = await next.Invoke(); //执行控制器的构造方法和Action方法
                //将resource.Result的值存到缓存
                Cache[key] = resource.Result;                           //将方法结果存储到缓存
            }
        }
    }
}
