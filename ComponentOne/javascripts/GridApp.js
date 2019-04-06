/**
 * Created by Multi on 2019/4/6.
 */

var appData = {
    getData:function(count){
        var countries = 'US,Germany,UK,Japan,Italy,Greece'.split(','),
            data = new wijmo.collections.ObservableArray();

        for(var i=0;i<count;i++)
        {
            data.push({
                id:i,
                country:countries[i%countries.length],
                date:new Date(2014,i%12,i%28),
                amount:Math.random() * 10000,
                active:i%4 == 0
            });
        }
        return data;
    }
};

// first grid for flexgrid
var grid = new wijmo.grid.FlexGrid("#gsFlexGrid");
grid.itemsSource = appData.getData(50);

var fgInitMethod = new wijmo.grid.FlexGrid('#cdInitMethod'),
    fgColsCollection = new wijmo.grid.FlexGrid('#cdColsCollection'),
    cv = new wijmo.collections.CollectionView(appData.getData(100));

fgInitMethod.initialize({
    isReadOnly:true,
    autoGenerateColumns:false,
    columns:[
        {header:'Country',binding:'country',width:'*'},
        {header:'Date',binding:'date'},
        {header:'Revenue',binding:'amount',format:'n2'},
        {header:'Active',binding:'active'},
    ],
    itemsSource:cv
});


// initialize the other grid using the columns collection.
fgColsCollection.autoGenerateColumns = false;
fgColsCollection.itemsSource = cv;
var c = new wijmo.grid.Column();
c.binding = 'country';
c.header = 'Country';
c.width = '*';
fgColsCollection.columns.push(c);

c = new wijmo.grid.Column();
c.binding = 'date';
c.header = 'Date';
fgColsCollection.columns.push(c);

c = new wijmo.grid.Column();
c.binding = 'amount';
c.header = 'Revenue';
fgColsCollection.columns.push(c);

c = new wijmo.grid.Column();
c.binding = 'active';
c.header = 'Active';
fgColsCollection.columns.push(c);


// selection module for flexGrid
// initialize grid and menu
var grid = new wijmo.grid.FlexGrid('#smFlexGrid'),
    menu = new wijmo.input.Menu('#smMenu'),
    cv = new wijmo.collections.CollectionView(appData.getData(100));

grid.itemsSource = cv;
updateMenuHeader();

menu.itemClicked.addHandler(function(sender){
    grid.selectionMode = sender.selectedValue;
    updateMenuHeader()
});

function updateMenuHeader(){
    menu.header = '<b>selection Mode:</b>'+menu.text;
}

// group for flexGrid
// initialize grid and menu
var ggrid = new wijmo.grid.FlexGrid('#gFlexGrid'),
    gMenu = new wijmo.input.Menu('#gMenu'),
    cv = new wijmo.collections.CollectionView(appData.getData(100));

ggrid.initialize({
    autoGenerateColumns:false,
    columns:[
        { header: 'Country', binding: 'country', width: 220 },
        { header: 'Date', binding: 'date',format:'MMM-dd-yyyy' },
        { header: 'Revenue', binding: 'amount', format: 'n0' ,width:90}
    ],
    itemsSource:cv
});
updateGMenuHeader();

gMenu.itemClicked.addHandler(function(sender){
    var groupBy = sender.selectedValue;
    cv.groupDescriptions.clear();
    if(groupBy)
    {
        var groupNames = groupBy.split(',');
        for(var i=0;i<groupNames.length;i++)
        {
            var groupName = groupNames[i];
            if(groupName == 'date')
            {
                var groupDesc = new wijmo.collections.PropertyGroupDescription(groupName,function(item,prop){
                    return item.date.getFullYear();
                });
                cv.groupDescriptions.push(groupDesc);
            }else if(groupName == 'amount')
            {
                var groupDesc = new wijmo.collections.PropertyGroupDescription(groupName,function(item,prop){
                    return item.amount >= 5000?'> 5,000':item.amount >= 500?'500 to 5,000':'<500';
                });
                cv.groupDescriptions.push(groupDesc);
            }else{
                var groupDesc = new wijmo.collections.PropertyGroupDescription(groupName);
                cv.groupDescriptions.push(groupDesc);
            }
        }
    }
    updateGMenuHeader();
});

function updateGMenuHeader()
{
    gMenu.header = '<b>Group By:</b> ' + gMenu.text;
}


// filter for flexGrid
// create grid, some data
var grid = new wijmo.grid.FlexGrid('#fFlexGrid'),
    cv = new wijmo.collections.CollectionView(appData.getData(100)),
    filterEl = document.getElementById('fFilter'),
    filterText = '';

grid.itemsSource = cv;

filterEl.addEventListener('input',function(){
    filterText = this.value.toLowerCase();
    cv.refresh();
});

cv.filter = function(item){
    return !filterText || item.country.toLowerCase().indexOf(filterText) > -1;
}


// pagination for flexGrid
// create a CollectionView ,set the page size to 10, initialize pager.

var cv = new wijmo.collections.CollectionView(appData.getData(100)),
    pageButtons = Array.prototype.slice.call(document.querySelectorAll('#pPager button'));

cv.pageSize = 10;
updatePager();

var grid = new wijmo.grid.FlexGrid('#pFlexGrid');
grid.itemsSource = cv;

pageButtons.forEach(function(el){
    el.addEventListener('click',function(){
        updatePager(this.getAttribute('data-action'));
    });
});


function updatePager(action){
    var display = document.getElementById('pn'),
        fb = document.getElementById('pfb'),
        sb = document.getElementById('psb'),
        sf = document.getElementById('psf'),
        ff = document.getElementById('pff'),
        enableBackwards = false,
        enableForwards = false;

    switch (action){
        case 'fast-backward':
            cv.moveToFirstPage();
            break;
        case 'step-backward':
            cv.moveToPreviousPage();
            break;
        case 'step-forward':
            cv.moveToNextPage();
            break;
        case 'fast-forward':
            cv.moveToLastPage();
            break;
    }

    // update the pager text
    display.innerHTML = (cv.pageIndex+1)+'/'+(cv.pageCount);

    // determine which pager buttons to enable/disable
    enableBackwards = cv.pageIndex <= 0;
    enableForwards = cv.pageIndex >= cv.pageCount - 1;

    // enable / disable pager buttons
    fb.disabled = enableBackwards;
    sb.disabled = enableBackwards;
    sf.disabled = enableForwards;
    ff.disabled = enableForwards;
}
/*
// use initialize to setup flex's property.
var grid = new wijmo.grid.FlexGrid('#id');
grid.initialize({
    id:'',
    isReadOnly:true,
    autoGenerateColumns:false,
    allowSorting:false,
    //itemsSource:cv,
    bind:{
        bind:'url',
        update:'url',
        disableServerRead:false
    },
    selectionMode:wijmo.grid.selectionMode.ListBox,
    allowResizing:wijmo.grid.allowResizing.None,
    childItemsPath:'Children',
    cssClass:'grid',
    columns:[
        {
            binding:'ID',
            header:'ID',
            width:'*',
            align:'center'
        },
    ]
});

 */