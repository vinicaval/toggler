import React, { Component } from 'react';

export class DetailsApplication extends Component {
    displayName = DetailsApplication.name

  constructor(props) {
      super(props);
      this.state = { application: {}, features: [], loading: true };

      fetch('api/feature/')
          .then(response => response.json())
          .then(data => {
              this.setState({ ...this.state, features: data, loading: false });
          });

      fetch('api/application/' + this.props.match.params.id ,)
          .then(response => response.json())
          .then(data => {
              this.setState({ ...this.state,application: data, loading: false });
          });
  }

    verifyChecked(idFeature) {
        let app = this.state.application;
        let feature = app.features.find(f => f.id == idFeature);
        return feature? feature.active : false;
    }

    changeChecked(idFeature) {
        let data = [...this.state.features];
        let index = data.findIndex(f => f.id === idFeature);
        data[index].active = !data[index].active;
        this.setState({ ...this.state, features: data })
    }

    renderApplicationDetailTable(features) {
    return (
      <table className='table'>
        <thead>
        <tr>
            <th></th>
            <th>Name</th>
            <th>Url</th>
          </tr>
        </thead>
        <tbody>
            {features.map(feature =>
                <tr key={feature.id}>
                    <td><input type="checkbox" disabled checked={this.verifyChecked(feature.id)} onChange={(ev) => this.changeChecked(feature.id)} /></td>
                    <td>{feature.name}</td>
                    <td>{feature.description}</td>
                </tr>
            )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : this.renderApplicationDetailTable(this.state.features);

    return (
        <div>
            <h1>Details of {this.state.application.name}</h1>
            {contents}
        </div>
    );
  }
}
