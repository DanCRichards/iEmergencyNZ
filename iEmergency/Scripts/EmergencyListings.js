
    function configureDropDownLists(MainContent_generalList, MainContent_specificList) {
        var fire = ['Rubbish Fire', 'House Fire', 'Car Fire', 'Scrub Fire', 'Structure Fire'];
        var hazard = ['Petrol / Diesel Spilt', 'Mercury Spill', 'Gas Leak', 'Unknown Hazardous Material'];
        var mva = ['Car', 'Truck', 'Motorcycle', 'Combination'];
        var rescue = ['Perons Trapped', 'Perons stuck at height', 'Perons stuck down manshaft'];
        var trauma = ['Shallow cut', 'Deep Cut', 'Motor Vehicle Accident', 'Head Injuiry'];
        var pain = ['Dull, overwhelming pain', 'Sharp Pain', 'Restriction of breath'];
        var poison = ['Glass Cleaner', 'Mercury', 'Metal', 'Amonia', 'Over-dosing'];



        switch (MainContent_generalList.value) {

            case 'Trauma':
                MainContent_specificList.options.length = 0;
                for (i = 0; i < trauma.length; i++) {
                    createOption(MainContent_specificList, trauma[i], trauma[i]);
                }
                break;

            case 'Posioning':
                MainContent_specificList.options.length = 0;
                for (i = 0; i < poison.length; i++) {
                    createOption(MainContent_specificList, posion[i], poison[i]);
                }
                break;

            case 'Chest Pain':
                MainContent_specificList.options.length = 0;
                for (i = 0; i < pain.length; i++) {
                    createOption(MainContent_specificList, pain[i], pain[i]);
                }
                break;

            case 'Fire':
                MainContent_specificList.options.length = 0;
                for (i = 0; i < fire.length; i++) {
                    createOption(MainContent_specificList, fire[i], fire[i]);
                }
                break;
            case 'Motor Vehicle Acident':
                MainContent_specificList.options.length = 0;
                for (i = 0; i < mva.length; i++) {
                    createOption(MainContent_specificList, mva[i], mva[i]);
                }
                break;
            case 'Hazardous Materials':
                MainContent_specificList.options.length = 0;
                for (i = 0; i < hazard.length; i++) {
                    createOption(MainContent_specificList, hazard[i], hazard[i]);
                }
                break;
            case 'Resuce':
                MainContent_specificList.options.length = 0;
                for (i = 0; i < rescue.length; i++) {
                    createOption(MainContent_specificList, rescue[i], rescue[i]);
                }
                break;


            default:
                MainContent_specificList.options.length = 0;
                break;
        }

    }

function createOption(ddl, text, value) {
    var opt = document.createElement('option');
    opt.value = value;
    opt.text = text;
    ddl.options.add(opt);
}