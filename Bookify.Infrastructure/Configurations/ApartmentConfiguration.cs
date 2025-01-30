﻿using Bookify.Domain.Apartments;
using Bookify.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations
{
    internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("apartments");

            builder.HasKey(a => a.Id);

            builder.OwnsOne(x => x.Address);

            builder.Property(a => a.Name)
                .HasMaxLength(200)
                .HasConversion(name => name.Value, value => new Name(value));

            builder.Property(a => a.Description)
                .HasMaxLength(2000)
                .HasConversion(description => description.Value, value => new Description(value));

            builder.OwnsOne(a => a.Price, priceBuilder =>
            {
                priceBuilder.Property(price => price.Currency)
                    .HasConversion(currency => currency.CurrencyCode, code => Currency.FromCode(code));
            });

            builder.OwnsOne(a => a.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(x => x.Currency)
                    .HasConversion(currency => currency.CurrencyCode, code => Currency.FromCode(code));
            });

        }
    }
}
