(() => {
    const form = document.getElementById('CreateBenchForm');

    const descriptionInput = document.getElementById('Description');
    const numberOfSeatsInput = document.getElementById('NumberOfSeats');
    const latitudeInput = document.getElementById('Latitude');
    const longitudeInput = document.getElementById('Longitude');

    const createBenchButton = document.getElementById('CreateBenchButton');

    form.addEventListener('keyup', () => {
        createBenchButton.disabled = (
            (descriptionInput.value === '') ||
            (numberOfSeatsInput.value === '') ||
            (latitudeInput.value === '') ||
            (longitudeInput.value === '')
        );
    });
})();