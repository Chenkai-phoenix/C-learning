using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
/*一、
1.依赖注入：Dependency Injection   DI     （需要啥类内声明啥，创建对象时框架自动赋值）
2.控制反转：Inversion of Control    IOC  (需要啥自己写) 
3.IOC的实现方式：DI和服务定位器（ServiceLocator）
二、DI的几个概念
（1）服务（service） ：对象
（2）注册服务：创建服务前的行为
（3）服务容器：负责管理注册的服务
（4）查询服务：创建对象及关联对象
（5）对象声明周期：Transient（瞬态）需要时新生成，用完就销毁；
                   Scoped（范围）范围内是获得同一个服务（对象）；
				   Singleton（单例）任意情况下获得同一个服务（对象）；

三.dotnet中DI的使用
1.服务类型与实现类型可能一致可能不一致（多态）；获得的服务类型必须与注册类型一致，而不是与提供服务类型一致；

2.服务类型尽量使用接口,实现类型使用类
3.dotnet的IOC组件名为：DependencyInjection(DI),包含了服务定位器ServiceLocator的功能；
4.安装DependencyInjection(DI)组件
5.命名空间：using Microsoft.Extensions.DependencyInjection;
6.实现步骤：
（1）创建一个服务集合
（2）服务注册（集合添加服务）
（3）从集合中创建服务提供对象
（4）向服务提供对象要服务对象
四、服务的生命周期
Transient（瞬态）需要时新生成，用完就销毁；（费内存）
Singleton（单例）任意情况下获得同一个服务（对象）； 类没有属性定义时使用
Scoped（范围）范围内是获得同一个服务（对象）：使用时由服务提供对象创建范围IServiceScope ss1 = sp.CreateScope()
五.
ServiceProvider，IServiceScope 都继承了IDisposable，涉及资源使用using（）
六.服务定位

 */
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //接口的一般使用
            //ITestService i1 = new TestServiceLmpl();
            //i1.Name = "cc";
            //i1.SayHi();
            //ITestService i2 = new TestServiceLmpl2();
            //i2.Name = "ll";
            //i2.SayHi();

            //DI使用
            ServiceCollection services = new ServiceCollection();    // 创建一个服务集合
            //服务注册
            services.AddTransient<TestServiceLmpl>();               // 集合添加服务，瞬态服务
            services.AddSingleton<TestServiceLmpl2>();              // 集合添加服务，单例服务
            services.AddScoped<TestServiceLmpl3>();                 // 集合添加服务，范围服务
            using (ServiceProvider sp = services.BuildServiceProvider())   // 从集合中创建服务提供对象
            {
                //瞬态服务对象 ----不是一个对象
                TestServiceLmpl testServicer1 = sp.GetService<TestServiceLmpl>(); // 向服务提供对象要服务对象
                testServicer1.Name = "TOM";
                testServicer1.SayHi();

                TestServiceLmpl testServicer2 = sp.GetService<TestServiceLmpl>(); // 向服务提供对象要服务对象
                testServicer2.Name = "lily";
                testServicer2.SayHi();
                Console.WriteLine(Object.ReferenceEquals(testServicer1,testServicer2)); //Object.ReferenceEquals判断是否是一个对象


                //单例服务对象 ----是同一个对象
                TestServiceLmpl2 testServicer3 = sp.GetService<TestServiceLmpl2>(); // 向服务提供对象要服务对象
                testServicer3.Name = "jack";
                testServicer3.SayHi();

                TestServiceLmpl2 testServicer4 = sp.GetService<TestServiceLmpl2>(); // 向服务提供对象要服务对象
                testServicer4.SayHi();
                Console.WriteLine(Object.ReferenceEquals(testServicer3, testServicer4)); //Object.ReferenceEquals判断是否是一个对象

                //范围服务对象（特殊）----范围内同一个对象，范围外对象不同
                using (IServiceScope ss1 = sp.CreateScope())
                {
                    TestServiceLmpl3 testServicer5 = ss1.ServiceProvider.GetService<TestServiceLmpl3>(); // 向服务提供对象要服务对象
                    testServicer5.Name = "本田君";
                    testServicer5.SayHi();

                    TestServiceLmpl3 testServicer6 = ss1.ServiceProvider.GetService<TestServiceLmpl3>(); // 向服务提供对象要服务对象
                    testServicer6.SayHi();
                    Console.WriteLine(Object.ReferenceEquals(testServicer5, testServicer6)); //Object.ReferenceEquals判断是否是一个对象

                    using (IServiceScope ss2 = sp.CreateScope())
                    {
                        TestServiceLmpl3 testServicer7 = ss2.ServiceProvider.GetService<TestServiceLmpl3>(); // 向服务提供对象要服务对象
                        testServicer7.Name = "花田月下子";
                        testServicer7.SayHi();
                        Console.WriteLine(Object.ReferenceEquals(testServicer5, testServicer7)); //Object.ReferenceEquals判断是否是一个对象
                    }
                }

            }
            //ID使用之，接口作服务注册类型，类做服务提供对象
            ServiceCollection services1 = new ServiceCollection();
            services1.AddScoped<ITestService,TestServiceLmpl>();     //接口作服务注册，类做服务提供者
            using (ServiceProvider sp1 = services1.BuildServiceProvider())
            {
                using (IServiceScope sscope = sp1.CreateScope())
                {
                    ITestService testService1 = sscope.ServiceProvider.GetService<ITestService>();  //与注册的服务类型保持一致
                    //TestServiceLmpl testService1 = sscope.ServiceProvider.GetService<TestServiceLmpl>();   
                    //虽然对象都是TestServiceLmpl,但是会报错，获得的服务类型必须与注册类型一致，而不是与提供服务类型一致
                    testService1.SayHi();
                    Console.WriteLine(testService1.GetType());
                }
            }

            //获取多个服务（GetServices<T>()）
            //一个服务接口由多个类实现
            services.AddScoped<ITestService, TestServiceLmpl>();
            services.AddScoped<ITestService, TestServiceLmpl2>();
            services.AddScoped<ITestService, TestServiceLmpl3>();
            using (ServiceProvider sp = services.BuildServiceProvider()) 
            {
                IEnumerable<ITestService> testservices = sp.GetServices<ITestService>();     //GetServices,获取多个服务
                Console.WriteLine("一个服务接口由多个类实现，获取多个服务GetServices:");
                foreach (var item in testservices)
                {
                    Console.WriteLine(item.GetType());
                }
                Console.WriteLine("一个服务接口由多个类实现，获取单个服务GetService:");      //当一个服务接口由多个类实现,使用GetService，
                                                                                         //获取到定义顺序的最后一个服务
                ITestService testservice = sp.GetService<ITestService>();
                Console.WriteLine(testservice.GetType());
            }
        }
    }
}
