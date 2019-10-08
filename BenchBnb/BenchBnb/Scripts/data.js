const airBenchData = (() => {

    const baseURL = 'http://localhost:49834/api/benches';

    async function getBenches()
    {
        return await fetch(baseURL);
    };

    const response = await getBenches();
    const benchInfo = await response.json();

    return {
        benchInfo
    };
})();