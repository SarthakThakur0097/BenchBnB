const airBenchBenchesHtml = (() => {
    debugger;
    function getTableHtml(benches) {
        // If we don't have any benches to display, return null.
        if (benches.length === 0) {
            return null;
        }

        const tableRowsHtml = benches.map(bench => `
      <tr>
        <td>${bench.Description}</td>
        <td>${bench.NumSeats}</td>
        <td>${bench.Latitude}/${bench.Longitude}</td>
            
        <td>${bench.HasReviews === true ? bench.AverageRating : 'No ratings'}</td>
        <td>${bench.UserDisplayName}</td>
        <td> <a href = "/Review/Create/${bench.BenchId}">Leave a review</a> </td>
      </tr>
    `);

        return `
      <h3>Benches</h3>
      <table class="table">
          <thead>
              <tr>
                  <th>Description</th>
                  <th># of Seats</th>
                  <th>Lat/Long</th>
                  <th>Overall Rating</th>
                  <th>Posted By</th>
              </tr>
          </thead>
          <tbody>
            ${tableRowsHtml.join('')}
          </tbody>
      </table>
    `;
    }

    return {
        getTableHtml
    };
})();