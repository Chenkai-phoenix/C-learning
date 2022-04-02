/*AOP
---IResouceFilter资源缓存筛选器（同步版）
1.使用：
     step1：声明一个新类继承: Attribute, IResourceFilter并重写IResourceFilter接口
	 step2:在需要的函数前标记[新类名]
例如：
	 [IResourceFilterTest]
	 void Test();
执行过程：
        IResourceFilterTest.OnResourceExecuting();
	    void Test();
	    IResourceFilterTest.OnResourceExecuted();
2.作用：
（1）定义一个缓存区域
（2）当请求时，根据缓存标识判断，若有缓存，返回缓存值；若没有缓存，做方法的计算的结果保存到缓存中
3.通过两个方法实现
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication2.AOP
{
    //IResouceFilter资源缓存
    public class IResourceFilterTest : Attribute, IResourceFilter
    {
        private Dictionary<string, object> Cache = new Dictionary<string, object>(); //创建一个缓存
        //在XXX资源之前
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string key = context.HttpContext.Request.Path.ToString();
            if (Cache.ContainsKey(key))
            {
                //有缓存，保存缓存的值；（只要context.Result赋值完就会return）
                context.Result = (IActionResult)Cache[key];
            }

            Console.WriteLine("IResourceFilterTest.ResourceExecuting");
        }

        //在XXX资源之后
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string key = context.HttpContext.Request.Path.ToString();
            Cache[key] = context.Result; // 讲方法的结果存放到缓存
            Console.WriteLine("IResourceFilterTest.ResourceExecuted");
        }
    }
}
