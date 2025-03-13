let generatedCodeValue = ''; // Variable für den generierten Code

function generateUniqueCode() {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    let code = '';
    for (let i = 0; i < 5; i++) {
        const randomIndex = Math.floor(Math.random() * characters.length);
        code += characters[randomIndex];
    }
    generatedCodeValue = code; // Speichert den generierten Code in der Variable
    
    return code;
}

function setGeneratedCode(elementId) {
    const generatedCodeElement = document.getElementById(elementId);
    if (generatedCodeElement) {
        generatedCodeValue = generateUniqueCode(); // Aktualisiert die Variable
        generatedCodeElement.textContent = generatedCodeValue; // Setzt den Code ins HTML-Element
    }
}

document.addEventListener('DOMContentLoaded', function () {
    setGeneratedCode('generatedCode');
    const steps = document.querySelectorAll('.modal-step'); // Alle Schritte
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');
    let currentStep = 0; // Start bei Schritt 0

    // Funktion zum Aktualisieren der Sichtbarkeit der Schritte
    function updateStep() {
        steps.forEach((step, index) => {
            step.classList.toggle('d-none', index !== currentStep);
        });

        // Back-Button nur sichtbar machen, wenn nicht am ersten Schritt
        prevBtn.classList.toggle('d-none', currentStep === 0);
        // Next-Button-Text ändern, wenn am letzten Schritt
        nextBtn.textContent = currentStep === steps.length - 1 ? 'Finish' : 'Next';
    }

    // Weiter-Button
    nextBtn.addEventListener('click', () => {
        if (currentStep < steps.length - 1) {
            currentStep++;
            updateStep();
        } else {
            // Die Formularfelder aus dem Modal auslesen und in die versteckten Felder setzen
            document.getElementById('UserID').value = 1;
            document.getElementById('selectedClass').value = document.getElementById('classDropdown').value;
            document.getElementById('selectedYear').value = document.getElementById('yearDropdown').value;
            document.getElementById('schoolYearInput').value = document.getElementById('schoolYear').value;
            document.getElementById('AbteilungInput').value = document.getElementById('Abteilung').value;
            document.getElementById('FachInput').value = document.getElementById('Fach').value;
            document.getElementById('generatedCodeInput').value = document.getElementById('generatedCode').innerText;


            const modal = document.getElementById('multiStepModal');
            const bootstrapModal = bootstrap.Modal.getInstance(modal);
            bootstrapModal.hide();
            document.querySelector('form').submit();
        }
    });

    // Zurück-Button
    prevBtn.addEventListener('click', () => {
        if (currentStep > 0) {
            currentStep--;
            updateStep();
        }
    });

    // Initiale Sichtbarkeit setzen
    updateStep();
});