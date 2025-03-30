using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ShopCreator.Core.Data;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ShopCreator.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            var certBase64 = Environment.GetEnvironmentVariable("DATABASE_CA");

            if (string.IsNullOrEmpty(certBase64))
            {
                throw new Exception("SSL certificate not found in environment variables.");
            }

            certBase64 = certBase64
                            .Replace("-----BEGIN CERTIFICATE-----", "")
                            .Replace("-----END CERTIFICATE-----", "")
                            .Replace("\r", "")
                            .Replace("\n", "");

            byte[] certBytes;
            try
            {
                certBytes = Convert.FromBase64String(certBase64);
            }
            catch (FormatException)
            {
                throw new Exception("The SSL certificate string is not a valid Base64 string.");
            }

            var cert = new X509Certificate2(certBytes);

            services.AddDbContext<AppDbContext>(options =>
            {
                var npgSqlConnection = new NpgsqlConnection(connectionString);

                npgSqlConnection.ProvideClientCertificatesCallback = certificates =>
                {
                    certificates.Add(cert);
                };

                options.UseNpgsql(npgSqlConnection);
            });
        }
    }
}
