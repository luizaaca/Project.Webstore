var refinementSelections = [];
var disallowUpdates = false;
var lastSelectedRefinementItemId;
var lastSelectedRefinementGroupId;
var lastActionWasToNarrowProductRefinement = false;

$().ready(function () {
    $('#ddlSortBy').change(function () {
        if (!disallowUpdates)
            displayPage(1);
    });

    $("#dialog-noproducts").dialog({
        bgiframe: true, autoOpen: false, height: 100, modal: true
    });
});


function displayPage(index) {
    if (!disallowUpdates) {

        var categoryId = $('#categoryId').val();
        var sortBy = $('#ddlSortBy').val();

        getProducts(index, categoryId, sortBy);
    }
}

function refineSearch(refinementGroupId, refinementItemId) {
    if (!disallowUpdates) {

        var itemRefinementElementId =
            buildRefinementItemElementIdFrom(refinementGroupId, refinementItemId);

        lastSelectedRefinementItemId = refinementItemId;
        lastSelectedRefinementGroupId = refinementGroupId;

        if (!isDisabled(itemRefinementElementId)) {
            if (isAvailable(itemRefinementElementId)) {
                setAsSelected(itemRefinementElementId);
                saveRefinementToFilterSelection(refinementGroupId, refinementItemId);
                lastActionWasToNarrowProductRefinement = true;
                displayPage(1);
            }
            else if (isSelectedButDisabled(itemRefinementElementId)) {
                setAsDisabled(itemRefinementElementId);
                removeRefinementFromFilterSelection(refinementGroupId, refinementItemId);
            }
            else {
                setAsAvailable(itemRefinementElementId);
                removeRefinementFromFilterSelection(refinementGroupId, refinementItemId);
                lastActionWasToNarrowProductRefinement = false;
                displayPage(1);
            }
        }
    }
}

function getProducts(index, categoryId, sortBy) {
    if (!disallowUpdates) {
        disallowUpdates = true;

        showOverlay("overlay", "main", 10);

        var jsonData = JSON.stringify({
            "CategoryId": categoryId,
            "PageIndex": index,
            "SortBy": sortBy,
            "RefinementGroups": refinementSelections
        });

        $.ajax({
            url: $("#base-url").val() + "/Product/GetProducts",
            type: "POST",
            dataType: "json",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var mydata = { items: data.Products };
                if (data.Products.length == 0) {
                    showNoProductsFoundDialogBoxAndRevertSelection();
                } else {
                    $("#items").setTemplate($("#product-item-template").html());
                    $("#items").processTemplate(mydata);
                    $("#number-products-found").text(data.NumberOfTitlesFound);
                    buildPageLinksFor("#page-links-top", data.CurrentPage, data.TotalNumberOfPages);
                    buildPageLinksFor("#page-links-bottom", data.CurrentPage, data.TotalNumberOfPages);

                    for (var i = 0; i < data.RefinementGroups.length; i++) {
                        filterOutRefinements(data.RefinementGroups[i].GroupId,
                            data.RefinementGroups[i].Refinements);
                    }
                }

                hideOverlay("overlay");

                disallowUpdates = false;
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
}

function filterOutRefinements(refinementGroupId, availableProductRefinements) {

    $("[id^='" + buildGroupRefinementElementIdFrom(refinementGroupId) + "']")
        .each(function () {

            var itemRefinementElementId = $(this).attr("id");

            var refinementItemId = findRefinementItemIdFrom(itemRefinementElementId);

            var refinementItemIdMatched =
                refinementItemIdIsInProductAvailableRefinements
                    (availableProductRefinements, refinementItemId);

            if (!lastSelectionWasMadeIn(refinementGroupId)) {
                if (lastActionWasToNarrowProductRefinement) {
                    if ((isSelected(itemRefinementElementId) ||
                        isSelectedButDisabled(itemRefinementElementId)) &&
                        !refinementItemIdMatched)
                        setAsSelectedButDisabled(itemRefinementElementId);
                    else if (!refinementItemIdMatched)
                        setAsDisabled(itemRefinementElementId);
                    else if (isDisabled(itemRefinementElementId) && refinementItemIdMatched)
                        setAsAvailable(itemRefinementElementId);
                    else if (isSelectedButDisabled(itemRefinementElementId)
                        && refinementItemIdMatched)
                        setAsSelected(itemRefinementElementId);
                } else {
                    if ((isSelected(itemRefinementElementId) ||
                        isSelectedButDisabled(itemRefinementElementId)) &&
                        !refinementItemIdMatched)
                        setAsSelectedButDisabled(itemRefinementElementId);
                    else if ((isSelected(itemRefinementElementId) ||
                        isSelectedButDisabled(itemRefinementElementId)) &&
                        refinementItemIdMatched)
                        setAsSelected(itemRefinementElementId);
                    else if (isDisabled(itemRefinementElementId) &&
                        refinementItemIdMatched)
                        setAsAvailable(itemRefinementElementId);
                    else if (isDisabled(itemRefinementElementId) &&
                        !refinementItemIdMatched &&
                        !otherRefinementSelectionsExistApartFrom(refinementGroupId))
                        setAsAvailable(itemRefinementElementId);
                    else if (isAvailable(itemRefinementElementId) &&
                        !refinementItemIdMatched)
                        setAsDisabled(itemRefinementElementId);
                }
            } else if (!lastActionWasToNarrowProductRefinement) {
                if (isSelected(itemRefinementElementId))
                    setAsSelected(itemRefinementElementId);
                else if (!otherRefinementSelectionsExistApartFrom(refinementGroupId))
                    setAsAvailable(itemRefinementElementId);
            } else if (isDisabled(itemRefinementElementId) && refinementItemIdMatched) {
                setAsAvailable(itemRefinementElementId);
            }
        });
}

function showNoProductsFoundDialogBoxAndRevertSelection() {
    var itemRefinementElementId =
        buildRefinementItemElementIdFrom(lastSelectedRefinementGroupId,
            lastSelectedRefinementItemId);

    setAsSelected(itemRefinementElementId);

    saveRefinementToFilterSelection(lastSelectedRefinementGroupId, lastSelectedRefinementItemId);

    $("#dialog-noproducts").dialog("open");
}

function findRefinementItemIdFrom(itemRefinementElementId) {
    var refinementItemId = 0;

    refinementItemId = 0;

    refinementItemId = itemRefinementElementId
        .substring(itemRefinementElementId.lastIndexOf("-") + 1, itemRefinementElementId.length);

    return refinementItemId
}

function lastSelectionWasMadeIn(refinementGroupId) {
    return lastSelectedRefinementGroupId == refinementGroupId;
}

function otherRefinementSelectionsExistApartFrom(refinementGroupId) {
    for (var i = 0; i < refinementSelections.length; i++) {
        if (refinementSelections[i].GroupId != refinementGroupId &&
            refinementSelections[i].SelectedRefinements.length > 0)
            return true;
    }
    return false;
}

function refinementItemIdIsInProductAvailableRefinements(availableProductRefinements,
    refinementItemId) {
    for (var i = 0; i < availableProductRefinements.length; i++) {
        if (availableProductRefinements[i].Id == refinementItemId)
            return true;
    }
    return false;
}


function removeRefinementFromFilterSelection(refinementGroupId, refinementItemId) {
    var refinementSelectionGroup = {};

    for (var i = 0; i < refinementSelections.length; i++) {
        if (refinementSelections[i].GroupId == refinementGroupId) {
            refinementSelectionGroup = refinementSelections[i];
            break;
        }
    }

    if (refinementSelectionGroup.GroupId == undefined) {
        refinementSelectionGroup.GroupId = refinementGroupId;
        refinementSelectionGroup.SelectedRefinements = [];
    }

    refinementSelectionGroup.SelectedRefinements
        .splice(refinementSelectionGroup.SelectedRefinements.indexOf(refinementItemId), 1);
}

function saveRefinementToFilterSelection(refinementGroupId, refinementItemId) {
    var refSelectionGroup = {};
    var foundExistingGroup = false;

    for (var i = 0; i < refinementSelections.length; i++) {
        if (refinementSelections[i].GroupId == refinementGroupId) {
            refSelectionGroup = refinementSelections[i];
            foundExistingGroup = true;
        }
    }

    if (!foundExistingGroup) {
        refSelectionGroup.GroupId = refinementGroupId;
        refinementSelections[refinementSelections.length] = refSelectionGroup;
        refSelectionGroup.SelectedRefinements = [];
    }

    refSelectionGroup
        .SelectedRefinements[refSelectionGroup.SelectedRefinements.length] = refinementItemId;
}

function buildPageLinksFor(spanId, index, totalPages) {

    var html = "";

    for (var i = 1; i <= totalPages; i++) {
        if (i == index)
            html = html +
                "<a class='selected' href='javascript:displayPage(" + i + ")'>" + i + "</a >&nbsp; ";
        else
            html = html +
                "<a href='javascript:displayPage(" + i + ")'>" + i + "</a >&nbsp; ";
    }

    $(spanId).html(html);
}

function setAsSelectedButDisabled(elementName) {
    $("#" + elementName).removeClass().addClass("selected-disabled-item");
}

function setAsSelected(elementName) {
    $("#" + elementName).removeClass().addClass("selected-item");
}

function setAsAvailable(elementName) {
    $("#" + elementName).removeClass().addClass("available-item");
}

function setAsDisabled(elementName) {
    $("#" + elementName).removeClass().addClass("disabled-item");
}

function isSelected(elementName) {
    return ($("#" + elementName).attr("class") == "selected-item");
}

function isAvailable(elementName) {
    return ($("#" + elementName).attr("class") == "available-item");
}

function isDisabled(elementName) {
    return ($("#" + elementName).attr("class") == "disabled-item");
}

function isSelectedButDisabled(elementName) {
    return ($("#" + elementName).attr("class") == "selected-disabled-item");
}

function buildGroupRefinementElementIdFrom(refinementGroupId) {
    return "refgroup-" + refinementGroupId;
}

function buildRefinementItemElementIdFrom(refinementGroupId, refinementItemId) {
    return "refgroup-" + refinementGroupId + "-" + refinementItemId;
}

function serviceFailed(result) {
    console.log("Service call failed: " + result.status + " " + result.statusText);
}