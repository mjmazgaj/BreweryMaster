import { fetchData, apiEndpoints } from "../../../../Shared/api";
import { createPath } from "../../../../Shared/helpers/useObjectHelper";

export const useFermentingIngredientsFilter = ({
  setFilterData,
  filterData,
  setTableData,
}) => {
  const handleSubmit = (event) => {
    event.preventDefault();

    let query = {
      TypeId: filterData?.typeId ? parseInt(filterData?.typeId) : "",
      Name: filterData?.name ?? "",
      UnitId: filterData?.unitId ? parseInt(filterData?.unitId) : "",
    };

    const path = createPath(apiEndpoints.fermentingIngredientSummary, query);
    fetchData(path, setTableData);
  };

  const handleSelectChange = (e, name) => {
    const { value } = e.target;
    setFilterData((prevData) => ({
      ...prevData,
      [name]: parseInt(value),
    }));
  };

  const handleClear = () => {
    setFilterData({
      control: [],
      dropdown: [],
    });
  };
  return {
    handleSelectChange,
    handleSubmit,
    handleClear,
  };
};
