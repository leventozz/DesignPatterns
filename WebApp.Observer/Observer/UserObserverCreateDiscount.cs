﻿using BaseProject.Models;

namespace WebApp.Observer.Observer
{
    public class UserObserverCreateDiscount : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverCreateDiscount(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();
            var context = _serviceProvider.GetRequiredService<AppIdentityDbContext>();

            context.Discounts.Add(new Models.Discount { Rate=10, UserId=appUser.Id });
            context.SaveChanges();
            logger.LogInformation("Discount created");
        }
    }
}
