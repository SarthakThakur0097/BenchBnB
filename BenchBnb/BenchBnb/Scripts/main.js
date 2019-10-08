(async () => {
    const baseURL = 'http://localhost:49834/api/benches';
    const benchesDivId = 'benches';
    const benchFilteringId = 'bench-filtering';
    const minNumberOfSeatsInputId = 'minNumberOfSeats';
    const maxNumberOfSeatsInputId = 'maxNumberOfSeats';
    
    const benchesDiv = document.getElementById(benchesDivId);
    const benchFiltering = document.getElementById(benchFilteringId);
    const minNumberOfSeatsInput = document.getElementById(minNumberOfSeatsInputId);
    const maxNumberOfSeatsInput = document.getElementById(maxNumberOfSeatsInputId);

    let filteredBenches = [];
    async function getBenches()
    {
        return await fetch(baseURL);
    };

    const response = await getBenches();
    const benchInfo = await response.json();

    benchesDiv.innerHTML = airBenchBenchesHtml.getTableHtml(benchInfo);

    benchFiltering.addEventListener('keyup', (event) => {
        debugger;
        const minNumberOfSeats = parseInt(minNumberOfSeatsInput.value, 10);
        const maxNumberOfSeats = parseInt(maxNumberOfSeatsInput.value, 10);

        const filteredBenches = benchInfo.filter(bench => 
            (isNaN(minNumberOfSeats) && isNaN(maxNumberOfSeats)) ||
            (isNaN(minNumberOfSeats) && bench.NumSeats <= maxNumberOfSeats) ||
            (isNaN(maxNumberOfSeats) && bench.NumSeats >= minNumberOfSeats) ||
            (bench.NumSeats >= minNumberOfSeats && bench.NumSeats <= maxNumberOfSeats)
        );

        benchesDiv.innerHTML = airBenchBenchesHtml.getTableHtml(filteredBenches);
    });

})();
