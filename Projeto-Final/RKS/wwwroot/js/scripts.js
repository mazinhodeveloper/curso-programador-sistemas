async function loadWeather() {
    const container = document.getElementById('forecast-container');
    container.innerHTML = '<div class="loading">Loading weather forecast...</div>';

    try {
        const response = await fetch('/weatherforecast');
        if (!response.ok) throw new Error('API error');

        const forecasts = await response.json();
        displayForecast(forecasts);
    } catch (error) {
        container.innerHTML = `<div class="error">❌ Error: ${error.message}</div>`;
    }
}

function displayForecast(forecasts) {
    const container = document.getElementById('forecast-container');
    container.innerHTML = `
        <div class="forecast-grid">
            ${forecasts.map(f => `
                <div class="forecast-card">
                    <div class="date">${new Date(f.date).toLocaleDateString()}</div>
                    <div class="temp">${f.temperatureC}°C / ${f.temperatureF}°F</div>
                    <div class="summary">${f.summary}</div>
                </div>
            `).join('')}
        </div>
    `;
}

// Load on page start
loadWeather();
