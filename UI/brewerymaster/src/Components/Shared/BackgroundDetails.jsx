import React, {Fragment} from "react";

import "./shared.css"

const BackgroundDetails = () => { 
    return (
      <Fragment>
        <div className="background-details">
          <div className="left-image">
            <img src="./glass.png" alt="" />
          </div>
          <div className="right-image">
            <img src="./bottle.png" alt="" />
          </div>
        </div>
      </Fragment>
    );
}

export default BackgroundDetails;