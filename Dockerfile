# .NET 10 SDK (preview)
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview

# Set working directory
WORKDIR /workspace

# Prevent dotnet first-time experience noise
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1 \
    DOTNET_NOLOGO=true

# Expose common ASP.NET ports (optional)
EXPOSE 5000
EXPOSE 5001

# Keep container alive for dev (VS Code / exec)
CMD ["sleep", "infinity"]
